using ExaminantionSystem.DTOS;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels;

namespace ExaminantionSystem.Services.user
{
    public interface IRoleeServices
    {
         

         public ResultViewModel<bool> CreateRolee(AddauthorizeRoleDto addauthorizeRoleDto);
     }
}
