
#nullable disable


namespace AimHigh.PL.Entities
{
    public class tblPriority : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public string ColorCode { get; set; }  // For UI representation

        public virtual ICollection<tblTask> Tasks { get; set; }
    }
}
