using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.PL.Entities
{
    public class tblTag : IEntity
    {
        public Guid Id { get; set; }

        public string Description {get; set; }

        public virtual ICollection<tblTask> tblTasks { get; set; }






    }
}
