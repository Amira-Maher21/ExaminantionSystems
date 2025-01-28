using ExaminantionSystem.DTOS;

namespace ExaminantionSystem.Services.courses
{
    public interface ICourseService
    {
        void Addcourse(CourseDto courseDto);
        IEnumerable<CourseDto> GetAllcourse();
        CourseDto Updatecourse(CourseDto courseDto);
        void Deletecourse(int courseId);
    }
}
