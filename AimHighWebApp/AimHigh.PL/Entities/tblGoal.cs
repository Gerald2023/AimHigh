using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.PL.Entities
{
    public class tblGoal: IEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public DateOnly Date { get; set; }

        public double Progress {  get; set; }


    }
}
