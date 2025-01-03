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

        // Navigation properties
        public virtual User Owner { get; set; }
        public virtual ICollection<Board> Boards { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }

    }
}
