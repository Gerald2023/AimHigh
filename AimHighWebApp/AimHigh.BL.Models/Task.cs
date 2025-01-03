using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimHigh.BL.Models.Enums;

namespace AimHigh.BL.Models
{
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
    }
}
