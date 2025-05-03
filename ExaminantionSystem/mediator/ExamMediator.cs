using ExaminantionSystem.DTOS;
using ExaminantionSystem.mediator;
using ExaminantionSystem.Services.Exams;
using ExaminantionSystem.Services.instructor;
using ExaminantionSystem.Services.Questions;
using ExaminationSystem.Models;

namespace ExaminantionSystem.mediator
{
    public class ExamMediator : IExamMediator
    {
        private readonly IExamService _examService;
        private readonly IinstructorService _instructorService;
        private readonly IQuestionService _questionService;


        public ExamMediator(IExamService examService,
                           IinstructorService iinstructorService,
                           IQuestionService questionService)
        {
            _examService = examService;
            _instructorService = iinstructorService;
            _questionService = questionService;
        }

        public void Add(ExamDto examDto)
        {
            throw new NotImplementedException();
        }



        //public void Add(ExamDto examDto)
        //{
        //    var instructor = _instructorService.GetById(examDto.InstructorId);
        //        if (instructor == null)
        //            throw new Exception("Instructor not found");

        //        var exam = new Exam
        //        {
        //            StartDate = examDto.StartDate,
        //            TotalGrade = examDto.TotalGrade,
        //            InstructorId = examDto.InstructorId
        //        };

        //        _examService.Add(exam);
        //    }

        //    public void AddQuestionToExam(int examId, int questionId)
        //    {
        //        var exam = _examService.GetById(examId);
        //        var question = _questionService.GetById(questionId);

        //        if (exam == null || question == null)
        //            throw new Exception("Exam or Question not found");

        //        var examQuestion = new ExamQuestion
        //        {
        //            ExamId = examId,
        //            QuestionId = questionId
        //        };

        //        exam.ExamQuestions.Add(examQuestion);
        //        _examService.Update(exam);

        //        // **إضافة نقاط للـ Instructor**
        //        var instructor = _instructorService.GetById(exam.InstructorId);
        //        if (instructor != null)
        //        {
        //            instructor.Points += 5; // كل سؤال يضيف 5 نقاط مثلاً
        //            _instructorService.Update(instructor);
        //        }
        //    }


    }

}
 