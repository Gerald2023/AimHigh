using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.BL.Models
{
    public class User
    {

        public Guid Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }


        public string? Email { get; set; }

        public string? Password { get; set; }


        [DisplayName("Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
