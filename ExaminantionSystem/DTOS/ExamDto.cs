using ExaminationSystem.Models;

namespace ExaminantionSystem.DTOS
{
    public class ExamDto
    {
        public ExamDto()
        {
            questionDtos = new HashSet<QuestionDto>();
        }


        public int ExamId { get; set; }
        public DateTime StartDate { get; set; }

        public int TotalGrade { get; set; }


        public HashSet<QuestionDto> questionDtos { get; set; }


    }
}
