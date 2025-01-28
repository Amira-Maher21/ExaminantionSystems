using System.ComponentModel.DataAnnotations;

namespace ExaminationSystem.Models
{
    public class BaseModel
    {
        public int ID { get; set; }

        public bool Deleted { get; set; }

        //[Timestamp]
        //public byte[] Flag { get; set; }
    }
}
