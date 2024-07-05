using AimHigh.BL.Models;
using AimHigh.PL.Data;
using AimHigh.PL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AimHigh.BL
{
    public class GoalManager : GenericManager<tblGoal>
    {
        public GoalManager(DbContextOptions<AimHighEntities> options) : base(options) { }

        public int Insert(Goal goal, bool rollback = false)
        {
            try
            {
                int result = base.Insert(new tblGoal
                {
                    Id = goal.Id,
                    UserId = goal.UserId,
                    Description = goal.Description,
                    ImagePath = goal.ImagePath,
                    Date = goal.Date,
                    Progress = goal.Progress

                }, rollback);

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Goal> Load()
        {

            try
            {
                List<Goal> rows = new List<Goal>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Goal
                        {
                            Id = d.Id,
                            UserId = d.UserId,
                            Title = d.Title,
                            Description = d.Description,
                            ImagePath = d.ImagePath,
                            Date = d.Date,
                            Progress = d.Progress
                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Goal LoadById(Guid id)
        {
            try
            {
                tblGoal row = base.LoadById(id);

                if (row != null)
                {
                    Goal goal = new Goal
                    {
                        Id = row.Id,
                        UserId = row.UserId,
                        Title = row.Title,
                        Description = row.Description,
                        ImagePath = row.ImagePath,
                        Date = row.Date,
                        Progress = row.Progress
                    };

                    return goal;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Goal goal, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblGoal
                {
                    Id = goal.Id,
                    UserId = goal.UserId,
                    Title = goal.Title,
                    Description = goal.Description,
                    ImagePath = goal.ImagePath,
                    Date = goal.Date,
                    Progress = goal.Progress

                }, rollback);
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return base.Delete(id, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
