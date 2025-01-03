using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace AimHigh.PL.Entities
{
    public class tblMilestone : IEntity
    {
        public Guid Id { get; set; }
        public Guid GoalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        // Navigation properties
        public virtual tblGoal Goal { get; set; }
        public virtual ICollection<tblTask> tblTasks { get; set; }
    }
}
