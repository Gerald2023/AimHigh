#nullable disable


using System.Data.Common;

namespace AimHigh.PL.Entities
{
    public class tblBoard : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        // Navigation properties
        public virtual tblProject Project { get; set; }
        public virtual ICollection<tblColumn> Columns { get; set; }
    }
}
