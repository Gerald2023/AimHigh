#nullable disable


using System.Data.Common;

namespace AimHigh.PL.Entities
{
    public class tblBoard : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        // Navigation properties
        public virtual tblProject Project { get; set; }
        public virtual ICollection<tblColumn> tblColumns { get; set; }
    }
}
