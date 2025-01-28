using ExaminationSystem.Models;

namespace ExaminantionSystem.DTOS
{
    public class QuestionDto
    {
        public QuestionDto()
        {
            choiceDto = new HashSet<ChoiceDto>();
        }

        public int QuestionId { get; set; }
        public string Text { get; set; }
        public int Grade { get; set; }
        public HashSet<ChoiceDto> choiceDto { get; set; }
    }
}
