using AimHigh.BL.Models;
using AimHigh.PL.Data;
using AimHigh.PL.Entities;
using Microsoft.EntityFrameworkCore;


namespace AimHigh.BL
{
    public class StatuskManager : GenericManager<tblStatus>
    {
        public StatuskManager(DbContextOptions<AimHighEntities> options) : base(options) { }

        public int Insert(Status status, bool rollback = false)
        {
            try
            {
                int result = base.Insert(new tblStatus
                {
                    Id = status.Id,
                    Title = status.Title,
                    Order = status.Order

                }, rollback);

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Status> Load()
        {

            try
            {
                List<Status> rows = new List<Status>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Status
                        {
                            Id = d.Id,
                            Title = d.Title,
                            Order = d.Order

                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Status LoadById(Guid id)
        {
            try
            {
                tblStatus row = base.LoadById(id);

                if (row != null)
                {
                    Status status = new Status
                    {
                        Id = row.Id,
                        Title = row.Title,
                        Order = row.Order
                    };

                    return status;
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

        public int Update(Status status, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblStatus
                {
                    Id = status.Id,
                    Title = status.Title,
                    Order = status.Order


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
