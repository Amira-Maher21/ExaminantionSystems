namespace ExaminationSystem.Models
{
    public class AuthorizeRole : BaseModel
    {
        public string Name { get; set; }

        public ICollection<RoleFeature> RoleFeatures { get; set; }

    }
}
