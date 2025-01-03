#nullable disable


namespace AimHigh.PL.Entities
{
    public class tblGoal : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public float Progress { get; set; }

        // Navigation properties
        public virtual tblProject Project { get; set; }
        public virtual ICollection<tblMilestone> Milestones { get; set; }
    }
}
