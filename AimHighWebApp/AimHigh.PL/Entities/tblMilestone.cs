using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.PL.Entities
{
    public class tblMilestone:IEntity
    {
        public Guid Id { get; set; }

        public string Title {  get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        
        public ICollection<tblTask>  tblTasks { get; set; }
    
    }
}
