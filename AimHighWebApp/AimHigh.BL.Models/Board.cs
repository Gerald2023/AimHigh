using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.BL.Models
{
    public class Board: BaseEntity
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public virtual Project Project { get; set; }
        public virtual ICollection<Column> Columns { get; set; }

    }
}
