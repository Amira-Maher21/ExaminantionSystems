using ExaminantionSystem.DTOS;
using ExaminationSystem.Models;

namespace ExaminantionSystem.Services.user
{
    public interface IRoleFeatureService
    {
          void AssignFeaturesToRole(AssignFeaturesToRoleDto dto);
     }

}
