using AimHigh.BL.Models;
using AimHigh.PL.Data;
using AimHigh.PL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AimHigh.BL
{
    public class MilestoneManager : GenericManager<tblMilestone>
    {
        public MilestoneManager(DbContextOptions<AimHighEntities> options) : base(options) { }

        public int Insert(Milestone milestone, bool rollback = false)
        {
            try
            {
                int result = base.Insert(new tblMilestone
                {
                    Id = milestone.Id,
                    GoalId = milestone.GoalId,
                    Title = milestone.Title,
                    Description = milestone.Description,
                    DueDate = milestone.DueDate,
                    Status = milestone.Status

                }, rollback);

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Milestone> Load()
        {

            try
            {
                List<Milestone> rows = new List<Milestone>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Milestone
                        {
                            Id = d.Id,
                            GoalId = d.GoalId,
                            Title = d.Title,
                            Description = d.Description,
                            DueDate = d.DueDate,
                            Status = d.Status
                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Milestone LoadById(Guid id)
        {
            try
            {
                tblMilestone row = base.LoadById(id);

                if (row != null)
                {
                    Milestone milestone = new Milestone
                    {
                        Id = row.Id,
                        GoalId = row.GoalId,
                        Title = row.Title,
                        Description = row.Description,
                        DueDate = row.DueDate,
                        Status = row.Status

                    };

                    return milestone;
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

        public int Update(Milestone milestone, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblMilestone
                {
                    Id = milestone.Id,
                    GoalId = milestone.GoalId,
                    Title = milestone.Title,
                    Description = milestone.Description,
                    DueDate = milestone.DueDate,

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
