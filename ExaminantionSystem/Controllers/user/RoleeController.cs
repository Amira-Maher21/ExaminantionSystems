using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExaminantionSystem.DTOS;
using ExaminantionSystem.Services.user;
using ExaminationSystem.ViewModels;

namespace ExaminantionSystem.Controllers.user
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleeController : ControllerBase
    {
        private readonly IRoleeServices _roleeServices;

        public RoleeController(IRoleeServices roleeServices)
        {
            _roleeServices = roleeServices;
        }

        [HttpPost("AddauthorizeRole")]
         public ActionResult<ResultViewModel<bool>> AddRole([FromBody] AddauthorizeRoleDto roleDto)
        {
            var result = _roleeServices.CreateRolee(roleDto);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

    }
}
