using AutoMapper;
using ExaminantionSystem.DTOS;
using ExaminantionSystem.Services.instructor;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;

namespace ExaminantionSystem.Services.courses
{

    public class CourseService : ICourseService
    {

        IRepository<Instructor> repository;
        IinstructorService iinstructorService;
        private readonly IMapper _mapper;


        public CourseService(IRepository<Instructor> repository,
           IinstructorService iinstructorService, IMapper mapper)
        {
            this.repository = repository;
            this.iinstructorService = iinstructorService;
            this._mapper = mapper;
        }
        public void Addcourse(CourseDto courseDto)
        {
            throw new NotImplementedException();
        }

        public void Deletecourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDto> GetAllcourse()
        {
            throw new NotImplementedException();
        }

        public CourseDto Updatecourse(CourseDto courseDto)
        {
            throw new NotImplementedException();
        }
    }
}
