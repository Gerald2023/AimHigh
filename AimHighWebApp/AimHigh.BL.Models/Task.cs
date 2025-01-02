using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.BL.Models
{
    public class Task
    {
        public string statusTitle;

        public Guid Id { get; set; }


        public Guid MilestoneId { get; set; } //FK
        public Guid UserId { get; set; } //FK
        public Guid StatusId { get; set; } //FK
        public Guid TagId { get; set; } //Fk
        public string Title { get; set; }   
        public string Description { get; set; }
        public DateTime Date { get; set; }


    }
}
