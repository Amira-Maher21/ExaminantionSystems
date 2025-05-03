using ExaminantionSystem.DTOS;
using ExaminantionSystem.Helpers;
using ExaminantionSystem.Services.Exams;
using ExaminantionSystem.Services.instructor;
using ExaminantionSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminantionSystem.Controllers.Examss
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
              _examService = examService;

        }

        [HttpGet]
        public ActionResult<IEnumerable<ExamViewModel>> GetAll()
        {
            var Examdata = _examService.GetAllExam()

                .Select(i => i.MapOne<ExamViewModel>());
            return Ok(Examdata);
        }


        [HttpPost]
        public IActionResult AddInstructorViewModel(ExamViewModel examViewModel)
        {
            try
            {
                var ExamDto = examViewModel.MapOne<ExamDto>();
                _examService.AddExam(ExamDto);

                return Ok("Instructor added successfully"); // ✅ إضافة `return`
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut]
        public IActionResult UpdateInstructor(ExamViewModel examViewModel)
        {
            try
            {
                // Map the ViewModel to the DTO
                var examdto = examViewModel.MapOne<ExamDto>();

                // Call the service method to update the instructor
                _examService.UpdateExam(examdto);

                return Ok("Instructor updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteInstructor(int id)
        {
            try
            {
                _examService.DeleteExam(id);
                return Ok("Instructor deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}


    


   



    



