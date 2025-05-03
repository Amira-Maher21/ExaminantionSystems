using ExaminationSystem.Models;

namespace ExaminantionSystem.DTOS
{
    public class QuestionDto
    {
        
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public int Grade { get; set; }

       // public List<string> Choices { get; set; } = new List<string>();

    }
}


 