namespace ExaminationSystem.Models
{
    public class RoleFeature : BaseModel
    {
        public Feature feature { get; set; }

        public int AuthorizeRoleID { get; set; }
        public AuthorizeRole Role { get; set; }
    }
}
