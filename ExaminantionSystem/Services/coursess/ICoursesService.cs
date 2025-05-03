using ExaminantionSystem.DTOS;

namespace ExaminantionSystem.Services.coursess
{
    public interface ICoursesService
    {
        IEnumerable<CourseDto> GetAllcourse();

        void Addcourse(CourseDto courseDto);
        void Updatecourse(CourseDto courseDto);
        void Deletecourse(int courseId);
    }
}
