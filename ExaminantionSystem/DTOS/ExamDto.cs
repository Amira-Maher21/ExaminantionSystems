﻿using ExaminationSystem.Models;

namespace ExaminantionSystem.DTOS
{
    public class ExamDto
    {
        


        public int ExamId { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public int TotalGrade { get; set; }




    }
}



 
