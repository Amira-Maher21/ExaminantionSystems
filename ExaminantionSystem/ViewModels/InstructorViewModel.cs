namespace ExaminantionSystem.ViewModels
{
    public class InstructorViewModel
    {
        public int InstructorId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
