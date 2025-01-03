using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.BL.Models
{
    public enum MilestoneStatus
    {
        NotStarted,
        InProgress,
        Completed,
        OnHold
    }

    public class Milestone : BaseEntity
    {
        public Guid GoalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public MilestoneStatus Status { get; set; }

        // Navigation properties
        public virtual Goal Goal { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
