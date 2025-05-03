using AutoMapper;
using ExaminantionSystem.DTOS;
using ExaminantionSystem.Services.coursess;
 using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminantionSystem.Services.courses
{

    public class CourseService : ICoursesService
    {

        private readonly IRepository<Course> _repository;
        private readonly IMapper _mapper;

        public CourseService(
            IRepository<Course> repository
             , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public IEnumerable<CourseDto> GetAllcourse()
        {
            var instructors = _repository.GetAll();

            //Method Group
            return instructors.Select(_mapper.Map<CourseDto>);
        }

        public void Addcourse(CourseDto courseDto)
        {
            var Course = _mapper.Map<Course>(courseDto);

             
            _repository.Add(Course);
            _repository.SaveChanges();
        }

        public void Updatecourse(CourseDto courseDto)
        {
            var existingInstructor = _repository.GetByID(courseDto.InstructorId);
            if (existingInstructor == null)
            {
                throw new ArgumentException($"Course with ID {courseDto.InstructorId} does not exist.");
            }

            _mapper.Map(courseDto, existingInstructor);

            _repository.Update(existingInstructor);
            _repository.SaveChanges();
        }

        public void Deletecourse(int courseId)
        {
            var Course = _repository.GetByID(courseId);
            if (Course == null)
            {
                throw new ArgumentException($"Course with ID {courseId} does not exist.");
            }

            _repository.Delete(Course);
            _repository.SaveChanges();
        }

        

        

    }
}
