using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.PL.Entities
{
    public class tblTask:IEntity
    {
        public Guid Id { get; set; }

        public Guid MilestoneId { get; set; }

        public Guid UserId { get; set; }

        public Guid TagId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateOnly Date { get; set; }

       
    }
}
