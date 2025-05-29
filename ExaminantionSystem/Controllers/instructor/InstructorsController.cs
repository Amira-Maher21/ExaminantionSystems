using AutoMapper;
using ExaminantionSystem.Data;
using ExaminantionSystem.DTOS;
using ExaminantionSystem.Helpers;
using ExaminantionSystem.Services.instructor;
using ExaminantionSystem.ViewModels;
using ExaminationSystem.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class InstructorController : ControllerBase
{
    private readonly IinstructorService _instructorService;
 
    public InstructorController(IinstructorService instructorService )
    {
        _instructorService = instructorService;
 
    }


    
    [HttpGet]
    public ActionResult<IEnumerable<InstructorViewModel>> GetAll()
    {
        var instructors = _instructorService.GetAllInstructors()

            .Select(i => i.MapOne<InstructorViewModel>());
        return Ok(instructors);
    }


    [HttpPost]
    public IActionResult AddInstructorViewModel(InstructorViewModel instructorViewModel)
    {
         var instructorDto = instructorViewModel.MapOne<InstructorDto>();
        _instructorService.AddInstructor(instructorDto);
        return CreatedAtAction(nameof(GetAll), new { id = instructorDto.InstructorId }, instructorViewModel);
    }


    [HttpPut]
    public IActionResult UpdateInstructor(InstructorViewModel instructorViewModel)
    {
        try
        {
            // Map the ViewModel to the DTO
            var instructorDto = instructorViewModel.MapOne<InstructorDto>();

            // Call the service method to update the instructor
            _instructorService.UpdateInstructor(instructorDto);

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
            _instructorService.DeleteInstructor(id);
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
