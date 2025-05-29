namespace ExaminantionSystem.DTOS
{
    public class LoginUserDto
    {
        public int UsersID { get; set; }
 
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AuthorizeRolesID { get; set; }
        public string AuthorizeRoleName { get; set; }
    }
    public class TokenDto
    {
        public int UsersID { get; set; }
        public string Name { get; set; }
        public string AuthorizeRoleName { get; set; }


    }
}
