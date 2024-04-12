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
        Guid[] taskId = new Guid[2];
        Guid[] tagId = new Guid[2];

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
            //put the connection string here to publish locally
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AimHigh.DB;Integrated Security=True");
            //optionsBuilder.UseLazyLoadingProxies();


        }

        public AimHighEntities()
        {          

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            //order matters here
            CreateUsers(modelBuilder);
            CreateGoals(modelBuilder);
            CreateMilestones(modelBuilder);
            CreateTags(modelBuilder);
            CreateTasks(modelBuilder);
         

        }

        private void CreateTags(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < tagId.Length; i++)
                tagId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblTag>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblTag_Id");
                entity.ToTable("tblTag");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description)
                .IsRequired()
                .IsUnicode(false);
            });

            // Sample data
            modelBuilder.Entity<tblTag>().HasData(new tblTag
            {
                Id = tagId[0],
                Description = "Personal"
            });
            modelBuilder.Entity<tblTag>().HasData(new tblTag
            {
                Id = tagId[1],
                Description = "Professional"
            });
        }

        private void CreateTasks(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < taskId.Length; i++)
                taskId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblTask>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblTask_Id");
                entity.ToTable("tblTask");

                entity.HasOne(d => d.Milestone)
                      .WithMany(p => p.tblTasks)
                      .HasForeignKey(d => d.MilestoneId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_tblTask_tblMilestone");

                entity.HasOne(d => d.User)
                      .WithMany(p => p.tblTasks)
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_tblTask_tblUser");

                entity.HasOne(d => d.Tag)
                      .WithMany()  // Remove the navigation property from the Many side
                      .HasForeignKey(d => d.TagId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_tblTask_tblTag");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Title)
                     .IsRequired()
                     .HasMaxLength(100)
                     .IsUnicode(false);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);
                entity.Property(e => e.Date)
                .HasColumnType("datetime");
            });

            // Adding sample data
            modelBuilder.Entity<tblTask>().HasData(new tblTask
            {
                Id = taskId[0], // Use the pre-generated task Id
                MilestoneId = milestoneId[0], // Assign valid MilestoneId
                UserId = userId[0], // Assign valid UserId
                TagId = tagId[0], // Assign valid TagId
                Title = "Complete Chapter 1",
                Description = "Read and complete exercises in Chapter 1 of the textbook.",
                Date = DateTime.Now.AddDays(7)
            });

            modelBuilder.Entity<tblTask>().HasData(new tblTask
            {
                Id = taskId[1], // Use the pre-generated task Id
                MilestoneId = milestoneId[1], // Assign valid MilestoneId
                UserId = userId[1], // Assign valid UserId
                TagId = tagId[1], // Assign valid TagId
                Title = "Write Book Review",
                Description = "Write a review of the latest book read.",
                Date = DateTime.Now.AddDays(14)
            });

        }

        private void CreateMilestones(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < milestoneId.Length; i++)
                milestoneId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblMilestone>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblMilestone_Id");
                entity.ToTable("tblMilestone");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Title)
                     .IsRequired()
                     .HasMaxLength(100)
                     .IsUnicode(false);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);
                entity.Property(e => e.Date)
                .HasColumnType("datetime");
            });

            // Adding sample data
            modelBuilder.Entity<tblMilestone>().HasData(new tblMilestone
            {
                Id = milestoneId[0],
                Title = "Complete Course 1",
                Description = "Finish the first online course.",
                Date = DateTime.Now.AddDays(30), // Set a future date for the milestone
                Status = "Pending"
            });

            modelBuilder.Entity<tblMilestone>().HasData(new tblMilestone
            {
                Id = milestoneId[1],
                Title = "Complete Course 2",
                Description = "Finish the second online course.",
                Date = DateTime.Now.AddDays(60), // Set a future date for the milestone
                Status = "Pending"
            });
        }

        private void CreateGoals(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < goalId.Length; i++)
                goalId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblGoal>(entity =>
            {
                //Primary Key
                entity.HasKey(e => e.Id).HasName("PK_tblGoal_Id");
                entity.ToTable("tblGoal");

                //foreign key with tblUser
                 entity.HasOne(d => d.User)
                .WithMany(p => p.tblGoals)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblGoal_tblUser");

                //more Fields
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Title)
                     .IsRequired()
                     .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);
                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Date)
                .HasColumnType("datetime");
                
                

            });

            //placing sample data

            modelBuilder.Entity<tblGoal>().HasData(new tblGoal
            {
                Id = goalId[0],
                UserId = userId[0], // 
                Title = "Learn ASP.NET Core",
                Description = "Complete online courses and build projects to learn ASP.NET Core.",
                ImagePath = "learn_aspnet_core.jpg",
                Date = new DateTime(2024, 5, 5),
                Progress = 0.0
            });

            modelBuilder.Entity<tblGoal>().HasData(new tblGoal
            {
                Id = goalId[1],
                UserId = userId[1],
                Title = "Read 20 Books",
                Description = "Read a variety of books across different genres.",
                ImagePath = "read_books.jpg",
                Date = new DateTime(2024, 9, 5),
                Progress = 0.0
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
