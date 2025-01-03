using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.BL.Models
{
    public class Column : BaseEntity
    {
        public Guid BoardId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int? WIPLimit { get; set; }  // Work In Progress limit

      
    }
}
