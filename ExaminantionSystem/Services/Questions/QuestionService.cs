using AutoMapper;
using ExaminantionSystem.DTOS;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminantionSystem.Services.Questions
{
    public class QuestionService : IQuestionService
    {
         private readonly IRepository<Question> _repository;
        private readonly IMapper _mapper;

        public QuestionService(
            IRepository<Question> repository
             , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }


        public void AddInstructor(QuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);

            _repository.Add(question);
            _repository.SaveChanges();
        }

    }
}
