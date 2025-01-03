#nullable disable

using System.Data.Common;

namespace AimHigh.PL.Entities
{
    public class tblUser : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Navigation properties
        public virtual ICollection<tblProject> Projects { get; set; }
        public virtual ICollection<tblTask> Tasks { get; set; }
    }
}
