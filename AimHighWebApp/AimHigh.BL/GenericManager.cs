

using AimHigh.PL.Data;
using AimHigh.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AimHigh.BL
{
    //Make it abstract so it cannot be instantiated directly
    public abstract class GenericManager<T> where T: class, IEntity
    {
        protected DbContextOptions<AimHighEntities> options;

        public GenericManager(DbContextOptions<AimHighEntities> options)
        {
            this.options = options;
        }

        public GenericManager() { }

        public List<T> Load()
        {
            try
            {
                return new AimHighEntities(options)
                    .Set<T>()
                    .ToList<T>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T> Load(string storedproc)
        {
            try
            {
                return new AimHighEntities(options)
                    .Set<T>()
                    .FromSqlRaw($"exec {storedproc} {"ct"}")
                    .ToList<T>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T> Load(string storedproc, string value)
        {
            try
            {
                return new AimHighEntities(options)
                    .Set<T>()
                    .FromSqlRaw($"exec {storedproc} {value}")
                    .ToList<T>();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public T LoadById(Guid id)
        {
            try
            {
                var row = new AimHighEntities(options).Set<T>().Where(t => t.Id == id).FirstOrDefault();
                return row;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (AimHighEntities dc = new AimHighEntities(options))
                {

                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    entity.Id = Guid.NewGuid();

                    dc.Set<T>().Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) dbTransaction.Rollback();

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (AimHighEntities dc = new AimHighEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    dc.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    results = dc.SaveChanges();

                    if (rollback) dbTransaction.Rollback();

                }

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
                int results = 0;
                using (AimHighEntities dc = new AimHighEntities(options))
                {
                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    T row = dc.Set<T>().FirstOrDefault(t => t.Id == id);

                    if (row != null)
                    {
                        dc.Set<T>().Remove(row);
                        results = dc.SaveChanges();
                        if (rollback) dbTransaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row does not exist.");
                    }

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
