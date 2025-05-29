using Microsoft.AspNetCore.Mvc;
using ExaminantionSystem.DTOS;
using ExaminantionSystem.Services.user;
using ExaminationSystem.ViewModels;

namespace ExaminantionSystem.Controllers.user
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleFeatureController : ControllerBase
    {
        private readonly IRoleFeatureService _service;

        public RoleFeatureController(IRoleFeatureService service)
        {
            _service = service;
        }

        [HttpPost("assign-features")]
        public IActionResult AssignFeaturesToRole([FromBody] AssignFeaturesToRoleDto dto)
        {
            try
            {
                _service.AssignFeaturesToRole(dto);
                return Ok(new { isSuccess = true, message = "Features assigned successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    isSuccess = false,
                    message = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
    }

}
