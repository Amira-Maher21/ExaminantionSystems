namespace ExaminantionSystem.DTOS
{
    public class LoginUserDto
    {
        public int UsersID { get; set; }
 
        public string UserName { get; set; }
        public string Password { get; set; }
       // public string AuthorizeRoleName { get; set; }
        public int AuthorizeRolesID { get; set; }
    }
}
