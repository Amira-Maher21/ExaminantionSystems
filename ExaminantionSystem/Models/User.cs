namespace ExaminationSystem.Models
{
    public class User : BaseModel
    {
         public string UserName { get; set; }
        public string Name { get; set; }   

        public string Password { get; set; }
        public int AuthorizeRoleID { get; set; }

        public AuthorizeRole AuthorizeRole { get; set; }
    }
}
