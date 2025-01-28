using ExaminationSystem.Models;

namespace ExaminantionSystem.DTOS
{
    public class CourseDto
    {
        public CourseDto()
        {
            listCourseDto = new HashSet<ListCourseDto>();
        }
        public int InstructorId { get; set; }
        public HashSet<ListCourseDto> listCourseDto { get; set; }

    }
    public class ListCourseDto
    {
         
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public int CreditHours { get; set; }

 
    }


}



