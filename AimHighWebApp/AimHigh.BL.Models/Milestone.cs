using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.BL.Models
{
    public class Milestone
    {
        public Guid Id { get; set; }

        public Guid GoalId { get; set; } //FK

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

    }
}
