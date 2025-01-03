#nullable disable


namespace AimHigh.PL.Entities
{
    // AimHigh.PL.Entities/tblProject.cs
    public class tblProject : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        // Navigation properties
        public virtual tblUser User { get; set; }
        public virtual ICollection<tblBoard> Boards { get; set; }
        public virtual ICollection<tblGoal> Goals { get; set; }
    }
}
