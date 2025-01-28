namespace ExaminationSystem.Models
{
    public class RoleFeature : BaseModel
    {
        public int AuthorizeRoleID { get; set; }

        public Feature Feature { get; set; }
        public AuthorizeRole Role { get; set; }
    }
}
