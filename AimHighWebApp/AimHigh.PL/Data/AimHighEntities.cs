using AimHigh.PL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimHigh.PL.Data
{
    public class AimHighEntities: DbContext
    {
        Guid[] userId = new Guid[2];
        Guid[] goalId = new Guid[3];
        Guid[] milestoneId = new Guid[3];
        Guid[] taskId = new Guid[3];
        Guid[] tagId = new Guid[3];

        public virtual DbSet<tblUser> tblUsers { get; set; }

        public virtual DbSet<tblGoal> tblGoals { get; set; }

        public virtual DbSet<tblMilestone> tblMilestones { get; set; }

        public virtual DbSet<tblTask> tblTasks { get; set; }

        public virtual DbSet<tblTag> tblTags { get; set; }

        public AimHighEntities(DbContextOptions<AimHighEntities> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //put the connection string here
        }

        public AimHighEntities()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            CreateUsers(modelBuilder);
            CreateGoals(modelBuilder);
            CreateMilestones(modelBuilder);
            CreateTasks(modelBuilder);
            CreateTags(modelBuilder);

        }

        private void CreateTags(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        private void CreateTasks(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        private void CreateMilestones(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        private void CreateGoals(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < goalId.Length; i++)
                goalId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblUser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblGoal_Id");
                entity.ToTable("tblGoal");


            });

            
        }

        private void CreateUsers(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < userId.Length; i++)
                userId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblUser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblUser_Id");
                entity.ToTable("tblUser");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(28)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<tblUser>().HasData(new tblUser
            {
                Id = userId[0],
                FirstName = "Steve",
                LastName = "Marin",
                Password = GetHash("maple"),
                Email = "smarin@sample.com"
            });
            modelBuilder.Entity<tblUser>().HasData(new tblUser
            {
                Id = userId[1],
                FirstName = "Gerald",
                LastName = "Vallejos",
                Password = GetHash("maple"),
                Email = "Gerald@sample.com"
            });

        }

        private static string GetHash(string Password)
        {
            using (var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }
    }
}
