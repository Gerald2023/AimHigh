using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace AimHigh.PL.Entities
{
    public class tblMilestone : BaseEntity
    {
        public Guid GoalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Guid MilestoneStatusId { get; set; }

        public virtual tblMilestoneStatus MilestoneStatus { get; set; }

        public virtual tblGoal Goal { get; set; }
        public virtual ICollection<tblTask> Tasks { get; set; }
    }
}
