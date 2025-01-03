using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.BL.Models
{

    public enum Priority
    {
        Low,
        Medium,
        High,
        Urgent
    }

    public class Task : BaseEntity
    {
        public Guid ColumnId { get; set; }
        public Guid? MilestoneId { get; set; }
        public Guid? AssigneeId { get; set; }
        public Guid? TagId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Order { get; set; }
        public Priority Priority { get; set; }

        // Navigation properties
        public virtual Column Column { get; set; }
        public virtual Milestone Milestone { get; set; }
        public virtual User Assignee { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
