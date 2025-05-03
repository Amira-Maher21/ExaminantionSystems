using ExaminantionSystem.DTOS;
using ExaminantionSystem.Helpers;
using ExaminantionSystem.Services.courses;
using ExaminantionSystem.Services.instructor;
using ExaminantionSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminantionSystem.Controllers.course
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase

    {
        private readonly ICourseService _icourseService;

        public CourseController(ICourseService icourseService)
        {
            _icourseService = icourseService;

        }

        //[HttpGet]
        //public ActionResult<IEnumerable<CourseViewModel>> GetAll()
        //{
        //    var instructors = _icourseService.GetAllInstructors()

        //        .Select(i => i.MapOne<InstructorViewModel>());
        //    return Ok(instructors);
        //}


        //[HttpPost]
        //public IActionResult AddInstructorViewModel(InstructorViewModel instructorViewModel)
        //{
        //    var instructorDto = instructorViewModel.MapOne<ListCourseDto>();
        //    _instructorService.AddInstructor(ListCourseDto);
        //    return CreatedAtAction(nameof(GetAll), new { id = ListCourseDto.InstructorId }, instructorViewModel);
        //}


        //[HttpPut]
        //public IActionResult UpdateInstructor(InstructorViewModel instructorViewModel)
        //{
        //    try
        //    {
        //        // Map the ViewModel to the DTO
        //        var instructorDto = instructorViewModel.MapOne<InstructorDto>();

        //        // Call the service method to update the instructor
        //        _instructorService.UpdateInstructor(instructorDto);

        //        return Ok("Instructor updated successfully.");
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}


        //[HttpDelete("{id}")]
        //public IActionResult DeleteInstructor(int id)
        //{
        //    try
        //    {
        //        _instructorService.DeleteInstructor(id);
        //        return Ok("Instructor deleted successfully.");
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}



        //[HttpGet]
        //public ActionResult<IEnumerable<InstructorViewModel>> GetAll()
        //{
        //    var instructors = _instructorService.GetAllInstructors()
        //        .Select(MapInstructorToViewModel);

        //    return Ok(instructors);
        //}

        //private InstructorViewModel MapInstructorToViewModel(InstructorDto instructorDto)
        //{
        //    return instructorDto.MapOne<InstructorViewModel>();
        //}


    }
}
