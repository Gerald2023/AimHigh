using AimHigh.BL.Models;
using AimHigh.PL.Data;
using AimHigh.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Task = AimHigh.BL.Models.Task;

namespace AimHigh.BL
{
    public class TaskManager : GenericManager<tblTask>
    {
        public TaskManager(DbContextOptions<AimHighEntities> options) : base(options) { }

        public int Insert(Task task, bool rollback = false)
        {
            try
            {
                int result = base.Insert(new tblTask
                {
                    Id = task.Id,
                    MilestoneId = task.MilestoneId,
                    UserId = task.UserId,
                    TagId = task.TagId,
                    Title = task.Title,
                    Description = task.Description,
                    Date = task.Date

                }, rollback);

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Task> Load()
        {

            try
            {
                List<Task> rows = new List<Task>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Task
                        {
                            Id = d.Id,
                            MilestoneId = d.MilestoneId,
                            UserId = d.UserId,
                            TagId = d.TagId,
                            Title = d.Title,
                            Description = d.Description,
                            Date = d.Date
                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task LoadById(Guid id)
        {
            try
            {
                tblTask row = base.LoadById(id);

                if (row != null)
                {
                    Task task = new Task
                    {
                        Id = row.Id,
                        MilestoneId = row.MilestoneId,
                        UserId = row.UserId,
                        TagId = row.TagId,
                        Title = row.Title,
                        Description = row.Description,
                        Date = row.Date
                    };

                    return task;
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

        public int Update(Task task, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblTask
                {
                    Id = task.Id,
                    MilestoneId = task.MilestoneId,
                    UserId = task.UserId,
                    TagId = task.TagId,
                    Title = task.Title,
                    Description = task.Description,
                    Date = task.Date

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
