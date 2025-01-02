
#nullable disable


namespace AimHigh.PL.Entities
{
    public class tblStatus : IEntity
    {
        public Guid Id { get; set; }

        public string Title {get; set; }

        public int Order { get; set; }

        public virtual ICollection<tblTask> tblTasks { get; set; }


    }
}
