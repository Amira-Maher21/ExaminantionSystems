using ExaminationSystem.Models;

namespace ExaminantionSystem.ViewModels
{
    public class ExamViewModel
    {
        public int ExamId { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public int TotalGrade { get; set; }
    }
}
