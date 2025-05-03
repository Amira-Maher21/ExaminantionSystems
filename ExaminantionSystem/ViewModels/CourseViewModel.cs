using ExaminationSystem.Models;

namespace ExaminantionSystem.ViewModels
{
    public class CourseViewModel
    {
        public string Name { get; set; }
        public int CreditHours { get; set; }
        public int InstructorID { get; set; }


        public CourseViewModel()
        {
            Exams = new HashSet<Exam>();
        }

        public HashSet<Exam> Exams { get; set; }
    }
}
