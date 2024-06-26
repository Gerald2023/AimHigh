﻿using AimHigh.BL;
using AimHigh.BL.Models;
using AimHigh.PL.Data;
using AimHigh.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace AimHigh.BL
{
    public class TagManager : GenericManager<tblTag>
    {
        public TagManager(DbContextOptions<AimHighEntities> options) : base(options) { }

        public int Insert(Tag tag, bool rollback = false)
        {
            try
            {
                tblTag row = new tblTag { Description = tag.Description };
                tag.Id = row.Id;
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Tag> Load()
        {

            try
            {
                List<Tag> rows = new List<Tag>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Tag
                        {
                            Id = d.Id,
                            Description = d.Description,
                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Tag LoadById(Guid id)
        {
            try
            {
                tblTag row = base.LoadById(id);

                if (row != null)
                {
                    Tag tag = new Tag
                    {
                        Id = row.Id,
                        Description = row.Description,
                    };

                    return tag;
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

        public int Update(Tag tag, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblTag
                {
                    Id = tag.Id,
                    Description = tag.Description
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
