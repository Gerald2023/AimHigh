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
/*        Guid[] userId = new Guid[2];
        Guid[] goalId = new Guid[2];
        Guid[] milestoneId = new Guid[2];
        Guid[] statusId = new Guid[3];
        Guid[] taskId = new Guid[2];
        Guid[] tagId = new Guid[2];*/


        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblProject> tblProjects { get; set; }
        public virtual DbSet<tblBoard> tblBoards { get; set; }
        public virtual DbSet<tblColumn> tblColumns { get; set; }
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
           optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AimHigh.DB;Integrated Security=True");

                        optionsBuilder.UseLazyLoadingProxies();


        }

        public AimHighEntities()
        {          

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            // Order matters for seeding data
            ConfigureUser(modelBuilder);
            ConfigureProject(modelBuilder);
            ConfigureBoard(modelBuilder);
            ConfigureColumn(modelBuilder);
            ConfigureGoal(modelBuilder);
            ConfigureMilestone(modelBuilder);
            ConfigureTag(modelBuilder);
            ConfigureTask(modelBuilder);

            SeedData(modelBuilder);





        }

        private void ConfigureUser(ModelBuilder modelBuilder)
        {
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
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                // Add unique index for email
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }

        private void ConfigureProject(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblProject>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblProject_Id");
                entity.ToTable("tblProject");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                // Relationship with User
                entity.HasOne(d => d.Owner)
                          .WithMany(p => p.Projects)
                          .HasForeignKey(d => d.OwnerId)
                          .OnDelete(DeleteBehavior.Restrict)
                          .HasConstraintName("FK_tblProject_tblUser");

                entity.HasIndex(e => e.OwnerId);
            });
        }

        private void ConfigureBoard(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblBoard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblBoard_Id");
                entity.ToTable("tblBoard");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                // Relationship with Project
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.tblBoards)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblBoard_tblProject");
            });
        }

        private void ConfigureColumn(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblColumn>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblColumn_Id");
                entity.ToTable("tblColumn");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                // Relationship with Board
                entity.HasOne(d => d.Board)
                    .WithMany(p => p.tblColumns)
                    .HasForeignKey(d => d.BoardId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblColumn_tblBoard");

                // Add index on Order for sorting
                entity.HasIndex(e => new { e.BoardId, e.Order });
            });
        }

        private void ConfigureGoal(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblGoal>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblGoal_Id");
                entity.ToTable("tblGoal");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);
                entity.Property(e => e.Progress)
                    .HasColumnType("float");
                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime");

                // Relationship with Project
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.tblGoals)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblGoal_tblProject");

                // Add index on ProjectId and DueDate
                entity.HasIndex(e => new { e.ProjectId, e.DueDate });
            });
        }

        private void ConfigureMilestone(ModelBuilder modelBuilder)
        {
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
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime");

                // Relationship with Goal
                entity.HasOne(d => d.Goal)
                    .WithMany(p => p.tblMilestones)
                    .HasForeignKey(d => d.GoalId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tblMilestone_tblGoal");

                // Add index on GoalId and DueDate
                entity.HasIndex(e => new { e.GoalId, e.DueDate });
            });
        }

        private void ConfigureTag(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblTag>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblTag_Id");
                entity.ToTable("tblTag");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(7)  // For hex color codes (#FFFFFF)
                    .IsUnicode(false);
            });
        }

        private void ConfigureTask(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblTask>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblTask_Id");
                entity.ToTable("tblTask");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);
                entity.Property(e => e.Priority)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime");

                // Relationships
                entity.HasOne(d => d.Column)
                    .WithMany(p => p.tblTasks)
                    .HasForeignKey(d => d.ColumnId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblTask_tblColumn");

                entity.HasOne(d => d.Milestone)
                    .WithMany(p => p.tblTasks)
                    .HasForeignKey(d => d.MilestoneId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tblTask_tblMilestone");

                entity.HasOne(d => d.Assignee)
                            .WithMany(p => p.Tasks)
                            .HasForeignKey(d => d.AssigneeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("FK_tblTask_tblUser");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.tblTasks)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_tblTask_tblTag");

                // Add indexes
                entity.HasIndex(e => new { e.ColumnId, e.Order });
                entity.HasIndex(e => e.AssigneeId);
                entity.HasIndex(e => e.MilestoneId);
            });
        }
        // Sample seed data method to add to OnModelCreating
        private void SeedData(ModelBuilder modelBuilder)
        {
            // Generate GUIDs for sample data
            var userId = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var boardId = Guid.NewGuid();
            var columnIds = new[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var goalId = Guid.NewGuid();
            var milestoneId = Guid.NewGuid();
            var tagIds = new[] { Guid.NewGuid(), Guid.NewGuid() };
            var taskIds = new[] { Guid.NewGuid(), Guid.NewGuid() };

            // Seed User
            modelBuilder.Entity<tblUser>().HasData(new tblUser
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = GetHash("SecurePass123"),
            });

            // Seed Project
            modelBuilder.Entity<tblProject>().HasData(new tblProject
            {
                Id = projectId,
                OwnerId = userId,
                Name = "Website Redesign",
                Description = "Complete overhaul of company website",
                CreatedAt = DateTime.UtcNow
            });

            // Seed Board
            modelBuilder.Entity<tblBoard>().HasData(new tblBoard
            {
                Id = boardId,
                ProjectId = projectId,
                Name = "Development Tasks",
                Description = "Track development progress",
                CreatedAt = DateTime.UtcNow
            });

            // Seed Columns
            modelBuilder.Entity<tblColumn>().HasData(
                new tblColumn
                {
                    Id = columnIds[0],
                    BoardId = boardId,
                    Name = "To Do",
                    Order = 1,
                    WIPLimit = 5,
                    CreatedAt = DateTime.UtcNow
                },
                new tblColumn
                {
                    Id = columnIds[1],
                    BoardId = boardId,
                    Name = "In Progress",
                    Order = 2,
                    WIPLimit = 3,
                    CreatedAt = DateTime.UtcNow
                },
                new tblColumn
                {
                    Id = columnIds[2],
                    BoardId = boardId,
                    Name = "Done",
                    Order = 3,
                    WIPLimit = null,
                    CreatedAt = DateTime.UtcNow
                }
            );

            // Seed Goal
            modelBuilder.Entity<tblGoal>().HasData(new tblGoal
            {
                Id = goalId,
                ProjectId = projectId,
                Title = "Launch New Website",
                Description = "Complete and launch the new company website",
                DueDate = DateTime.UtcNow.AddMonths(3),
                Progress = 0,
                CreatedAt = DateTime.UtcNow
            });

            // Seed Milestone
            modelBuilder.Entity<tblMilestone>().HasData(new tblMilestone
            {
                Id = milestoneId,
                GoalId = goalId,
                Title = "Frontend Development",
                Description = "Complete all frontend components",
                DueDate = DateTime.UtcNow.AddMonths(1),
                Status = "NotStarted",
                CreatedAt = DateTime.UtcNow
            });

            // Seed Tags
            modelBuilder.Entity<tblTag>().HasData(
                new tblTag
                {
                    Id = tagIds[0],
                    Name = "Frontend",
                    Color = "#FF5733",
                    CreatedAt = DateTime.UtcNow
                },
                new tblTag
                {
                    Id = tagIds[1],
                    Name = "High Priority",
                    Color = "#C70039",
                    CreatedAt = DateTime.UtcNow
                }
            );

            // Seed Tasks
            modelBuilder.Entity<tblTask>().HasData(
                new tblTask
                {
                    Id = taskIds[0],
                    ColumnId = columnIds[0],
                    MilestoneId = milestoneId,
                    AssigneeId = userId,
                    TagId = tagIds[0],
                    Title = "Design Homepage",
                    Description = "Create responsive design for homepage",
                    DueDate = DateTime.UtcNow.AddDays(7),
                    Order = 1,
                    Priority = "High",
                    CreatedAt = DateTime.UtcNow
                },
                new tblTask
                {
                    Id = taskIds[1],
                    ColumnId = columnIds[0],
                    MilestoneId = milestoneId,
                    AssigneeId = userId,
                    TagId = tagIds[1],
                    Title = "Setup Navigation",
                    Description = "Implement responsive navigation menu",
                    DueDate = DateTime.UtcNow.AddDays(5),
                    Order = 2,
                    Priority = "Medium",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }


        private static string GetHash(string password)
        {
            using (var hasher = new System.Security.Cryptography.SHA256Managed())
            {
                var hashBytes = System.Text.Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(hasher.ComputeHash(hashBytes));
            }
        }
    }
}
