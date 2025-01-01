using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.BL.Models
{
    public class Status
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        
        public int Order { get; set; }
    }
}
