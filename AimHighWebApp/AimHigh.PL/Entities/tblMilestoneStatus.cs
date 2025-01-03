#nullable disable


using System.Data.Common;

namespace AimHigh.PL.Entities
{
    public class tblMilestoneStatus : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<tblMilestone> Milestones { get; set; }
    }
}
