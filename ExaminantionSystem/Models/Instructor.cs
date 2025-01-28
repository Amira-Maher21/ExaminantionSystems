 using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    [Table("Instructor", Schema = "HR")]
    public class Instructor : BaseModel
    {
        public Instructor() 
        {
            Exams = new HashSet<Exam>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }
        public DateTime EnrollmentDate { get; set; }
       public HashSet<Exam> Exams { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
