#nullable disable


namespace AimHigh.PL.Entities
{
    public class tblGoal: IEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public DateTime Date { get; set; }

        public double Progress {  get; set; }


        //this is needed for the Context Entity relationship with User
        public virtual tblUser User { get; set; }


    }
}
