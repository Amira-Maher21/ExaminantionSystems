﻿namespace ExaminantionSystem.DTOS
{
    public class RegisterDto
    {
        public string Name { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Instructor or Student
    }

}
