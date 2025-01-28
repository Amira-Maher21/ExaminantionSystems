namespace ExaminantionSystem.DTOS
{
    public class ChoiceDto
    {
        public int ChoiceId { get; set; }
        public string Text { get; set; }

        public bool IsRightAnswer { get; set; }

         public int QuestionID { get; set; }
    }
}
