using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.BL.Models
{
    public class Goal
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; } //FK

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public DateTime Date {  get; set; }

        public double Progress {  get; set; } //by using double I ensure more precision over using float

    }
}
