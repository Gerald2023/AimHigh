
#nullable disable


namespace AimHigh.PL.Entities
{
    public class tblTag : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }


        // Navigation properties
        public virtual ICollection<tblTask> Tasks { get; set; }
    }
}
