using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace AimHigh.PL.Entities
{
    public class tblTask : IEntity
    {
        public Guid Id { get; set; }
        public Guid ColumnId { get; set; }
        public Guid? MilestoneId { get; set; }
        public Guid? AssigneeId { get; set; }
        public Guid? TagId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Order { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        // Navigation properties
        public virtual tblColumn Column { get; set; }
        public virtual tblMilestone Milestone { get; set; }
        public virtual tblUser Assignee { get; set; }
        public virtual tblTag Tag { get; set; }
    }

}
