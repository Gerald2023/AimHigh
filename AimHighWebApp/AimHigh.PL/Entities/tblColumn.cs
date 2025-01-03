#nullable disable


namespace AimHigh.PL.Entities
{
    public class tblColumn : BaseEntity
    {
        public Guid BoardId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int? WIPLimit { get; set; }

        // Navigation properties
        public virtual tblBoard Board { get; set; }
        public virtual ICollection<tblTask> Tasks { get; set; }
    }
}
