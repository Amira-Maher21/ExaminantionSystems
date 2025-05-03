using ExaminantionSystem.DTOS;
using ExaminationSystem.Models;

namespace ExaminantionSystem.Services.Exams
{
    public interface IExamService
    {
        void AddExam(ExamDto examDto);

        ExamDto GetById(int Examid);
        IEnumerable<ExamDto> GetAllExam();

        void UpdateExam(ExamDto examDto);
        void DeleteExam(int Examid);
  
        

    }
}
