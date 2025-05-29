using AutoMapper.Features;
using ExaminantionSystem.Models;
using ExaminationSystem.Models;

namespace ExaminantionSystem.DTOS
{
    public class RoleDto
    {
        public int AuthorizeRoleId { get; set; }
        public string Name { get; set; }

        public int RoleFeatureId { get; set; }
        public List<Feature> features { get; set; }
    }
    public class AssignFeaturesToRoleDto
    {
        public int RoleId { get; set; }
        public List<Feature> FeatureIds { get; set; }
    }


    public class EditeRoleDto
    {
        public int RoleID { get; set; }

        public IEnumerable<Feature> features { get; set; }
    }
    public class AddauthorizeRoleDto
    {
        public string RoleName { get; set; }
        public int AuthorizeRoleID { get; set; }
        

    }


}
