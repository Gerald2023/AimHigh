#nullable disable


namespace AimHigh.PL.Entities
{
    public class tblColumn : IEntity
    {
        public Guid Id { get; set; }
        public Guid BoardId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int? WIPLimit { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        // Navigation properties
        public virtual tblBoard Board { get; set; }
        public virtual ICollection<tblTask> tblTasks { get; set; }
    }
}
