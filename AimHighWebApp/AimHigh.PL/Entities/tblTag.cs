
#nullable disable


namespace AimHigh.PL.Entities
{
    public class tblTag : IEntity
    {
        public Guid Id { get; set; }

        public string Description {get; set; }

        public virtual ICollection<tblTask> tblTasks { get; set; }






    }
}
