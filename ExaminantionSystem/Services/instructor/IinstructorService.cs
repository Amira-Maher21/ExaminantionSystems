using ExaminantionSystem.DTOS;

namespace ExaminantionSystem.Services.instructor
{
    public interface IinstructorService
    {
        void AddInstructor(InstructorDto instructorDto); 
        IEnumerable<InstructorDto> GetAllInstructors();
        IEnumerable<ExamDto> GetById(int id);
        void UpdateInstructor(InstructorDto instructorDto);  
        void DeleteInstructor(int instructorId);  

    }
}
