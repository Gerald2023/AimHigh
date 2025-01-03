#nullable disable


namespace AimHigh.PL.Entities
{
    // AimHigh.PL.Entities/tblProject.cs
    public class tblProject : IEntity
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        // Navigation properties
        public virtual tblUser Owner { get; set; }
        public virtual ICollection<tblBoard> tblBoards { get; set; }
        public virtual ICollection<tblGoal> tblGoals { get; set; }
    }
}
