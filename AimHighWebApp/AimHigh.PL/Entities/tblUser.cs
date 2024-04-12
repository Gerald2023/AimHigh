#nullable disable

namespace AimHigh.PL.Entities
{
    public class tblUser:IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        //needed for the db relationship with tblGoal on AimHighEntities : Many
        public virtual ICollection<tblGoal> tblGoals { get; set; }

        public virtual ICollection<tblTask> tblTasks { get; set; }



    }
}
