using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.PL.Entities
{
    public class tblUser:IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }


    }
}
