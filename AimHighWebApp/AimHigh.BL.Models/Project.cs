using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.BL.Models
{
    public class Project: BaseEntity
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

       

    }
}
