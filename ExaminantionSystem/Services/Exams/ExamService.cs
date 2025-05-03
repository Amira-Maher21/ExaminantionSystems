using AutoMapper;
using ExaminantionSystem.DTOS;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExaminantionSystem.Services.Exams
{
    public class ExamService : IExamService
    {
        private readonly IRepository<Exam> _repository;
        private readonly IMapper _mapper;

        public ExamService(
            IRepository<Exam> repository
             , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public IEnumerable<ExamDto> GetAllExam()
        {
            var examdata = _repository.GetAll();

            return examdata.Select(_mapper.Map<ExamDto>);


        }


        public void AddExam(ExamDto examDto)
        {
            var examdata = _mapper.Map<Exam>(examDto);

            _repository.Add(examdata);
            _repository.SaveChanges();
        }




        public ExamDto GetById(int Examid)
        {
            var exam = _repository.First(s => s.ID == Examid);
            if (exam == null)
                throw new Exception("Exam not found");

            return _mapper.Map<ExamDto>(exam);
        }







        

        
        public void UpdateExam(ExamDto examDto)
        {
            var existingInstructor = _repository.GetByID(examDto.ExamId);
            if (existingInstructor == null)
            {
                throw new ArgumentException($"Instructor with ID {examDto.ExamId} does not exist.");
            }

            _mapper.Map(examDto, existingInstructor);

            _repository.Update(existingInstructor);
            _repository.SaveChanges();
        }


        public void DeleteExam(int Examid)
        {
            var instructor = _repository.GetByID(Examid);
            if (instructor == null)
            {
                throw new ArgumentException($"Instructor with ID {Examid} does not exist.");
            }

            _repository.Delete(instructor);
            _repository.SaveChanges();
        }

    }
}
