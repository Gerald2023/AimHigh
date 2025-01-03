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


        // First: Independent tables (no foreign keys)
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblTag> tblTags { get; set; }
        public virtual DbSet<tblMilestoneStatus> tblMilestoneStatuses { get; set; }
        public virtual DbSet<tblPriority> tblPriorities { get; set; }

        // Second: Tables with single foreign key dependencies
        public virtual DbSet<tblProject> tblProjects { get; set; }

        // Third: Tables with multiple foreign key dependencies
        public virtual DbSet<tblBoard> tblBoards { get; set; }
        public virtual DbSet<tblGoal> tblGoals { get; set; }

        // Fourth: Deeply dependent tables
        public virtual DbSet<tblColumn> tblColumns { get; set; }
        public virtual DbSet<tblMilestone> tblMilestones { get; set; }

        // Fifth: Most dependent tables
        public virtual DbSet<tblTask> tblTasks { get; set; }
        
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

            ConfigureUser(modelBuilder);
            ConfigureTag(modelBuilder);
            ConfigureMilestoneStatus(modelBuilder);
            ConfigurePriority(modelBuilder);
            ConfigureProject(modelBuilder);
            ConfigureBoard(modelBuilder);
            ConfigureGoal(modelBuilder);
            ConfigureColumn(modelBuilder);
            ConfigureMilestone(modelBuilder);
            ConfigureTask(modelBuilder);
            SeedData(modelBuilder);


        }



        private void ConfigureMilestoneStatus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblMilestoneStatus>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblMilestoneStatus_Id");
                entity.ToTable("tblMilestoneStatus");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.DisplayOrder)
                    .IsRequired();
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValue(true);

                // Add unique constraint on Name
                entity.HasIndex(e => e.Name).IsUnique();
                // Add index on DisplayOrder
                entity.HasIndex(e => e.DisplayOrder);
            });
        }

        private void ConfigurePriority(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblPriority>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblPriority_Id");
                entity.ToTable("tblPriority");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.DisplayOrder)
                    .IsRequired();
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValue(true);
                entity.Property(e => e.ColorCode)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                // Add unique constraint on Name
                entity.HasIndex(e => e.Name).IsUnique();
                // Add index on DisplayOrder
                entity.HasIndex(e => e.DisplayOrder);
            });
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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Projects)
                    .IsRequired() 
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProject_tblUser");

                entity.HasIndex(e => e.UserId);
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

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Boards)
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

                entity.HasOne(d => d.Board)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BoardId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblColumn_tblBoard");

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

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblGoal_tblProject");

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
                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime");

                // Relationship with MilestoneStatusId
                entity.HasOne(d => d.MilestoneStatus)
                    .WithMany(p => p.Milestones)
                    .HasForeignKey(d => d.MilestoneStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tblMilestone_tblMilestoneStatus");

                // Relationship with Goal
                entity.HasOne(d => d.Goal)
                    .WithMany(p => p.Milestones)
                    .HasForeignKey(d => d.GoalId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tblMilestone_tblGoal");

                entity.HasIndex(e => new { e.GoalId, e.DueDate });
                entity.HasIndex(e => e.MilestoneStatusId);
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
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });
        }

        private void ConfigureTask(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblTask>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.Id).HasName("PK_tblTask_Id");
                entity.ToTable("tblTask");

                // Base Properties
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime").IsRequired(false);

                // Task Properties
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.Order)
                    .IsRequired();

                // Required Relationships
                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ColumnId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tblTask_tblColumn");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.PriorityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tblTask_tblPriority");

                // Optional Relationships
                entity.HasOne(d => d.Milestone)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.MilestoneId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(false)
                    .HasConstraintName("FK_tblTask_tblMilestone");

                entity.HasOne(d => d.Assignee)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.AssigneeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired(false)
                    .HasConstraintName("FK_tblTask_tblUser");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired(false)
                    .HasConstraintName("FK_tblTask_tblTag");

                // Indexes
                entity.HasIndex(e => new { e.ColumnId, e.Order });
                entity.HasIndex(e => e.AssigneeId);
                entity.HasIndex(e => e.MilestoneId);
                entity.HasIndex(e => e.PriorityId);
            });
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // 1. Independent Entities (no FK dependencies)

            // MilestoneStatus
            var statusNotStarted = Guid.NewGuid();
            var statusInProgress = Guid.NewGuid();
            var statusCompleted = Guid.NewGuid();

            modelBuilder.Entity<tblMilestoneStatus>().HasData(
                new tblMilestoneStatus { Id = statusNotStarted, Name = "Not Started", Description = "Milestone not started", DisplayOrder = 1, IsActive = true },
                new tblMilestoneStatus { Id = statusInProgress, Name = "In Progress", Description = "Milestone in progress", DisplayOrder = 2, IsActive = true },
                new tblMilestoneStatus { Id = statusCompleted, Name = "Completed", Description = "Milestone completed", DisplayOrder = 3, IsActive = true }
            );

            // Priority
            var priorityLow = Guid.NewGuid();
            var priorityMedium = Guid.NewGuid();
            var priorityHigh = Guid.NewGuid();

            modelBuilder.Entity<tblPriority>().HasData(
                new tblPriority { Id = priorityLow, Name = "Low", Description = "Low priority", DisplayOrder = 1, IsActive = true, ColorCode = "#00FF00" },
                new tblPriority { Id = priorityMedium, Name = "Medium", Description = "Medium priority", DisplayOrder = 2, IsActive = true, ColorCode = "#FFFF00" },
                new tblPriority { Id = priorityHigh, Name = "High", Description = "High priority", DisplayOrder = 3, IsActive = true, ColorCode = "#FF0000" }
            );

            // Tags
            var tagBug = Guid.NewGuid();
            var tagFeature = Guid.NewGuid();

            modelBuilder.Entity<tblTag>().HasData(
                new tblTag { Id = tagBug, Name = "Bug", Color = "#FF0000" },
                new tblTag { Id = tagFeature, Name = "Feature", Color = "#00FF00" }
            );

            // Users
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();

            modelBuilder.Entity<tblUser>().HasData(
                new tblUser { Id = userId1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Password = GetHash("password123") },
                new tblUser { Id = userId2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Password = GetHash("password123") }
            );

            // 2. First Level Dependencies

            // Projects
            var projectId1 = Guid.NewGuid();
            var projectId2 = Guid.NewGuid();

            modelBuilder.Entity<tblProject>().HasData(
                new tblProject
                {
                    Id = projectId1,
                    UserId = userId1,
                    Name = "Project Alpha",
                    Description = "First project",
                    CreatedAt = DateTime.UtcNow
                },
                new tblProject
                {
                    Id = projectId2,
                    UserId = userId2,
                    Name = "Project Beta",
                    Description = "Second project",
                    CreatedAt = DateTime.UtcNow
                }
            );

            // 3. Second Level Dependencies

            // Boards
            var boardId1 = Guid.NewGuid();
            var boardId2 = Guid.NewGuid();

            modelBuilder.Entity<tblBoard>().HasData(
                new tblBoard
                {
                    Id = boardId1,
                    ProjectId = projectId1,
                    Name = "Main Board",
                    Description = "Main project board",
                    CreatedAt = DateTime.UtcNow
                },
                new tblBoard
                {
                    Id = boardId2,
                    ProjectId = projectId2,
                    Name = "Sprint Board",
                    Description = "Sprint planning board",
                    CreatedAt = DateTime.UtcNow
                }
            );

            // Goals
            var goalId1 = Guid.NewGuid();
            var goalId2 = Guid.NewGuid();

            modelBuilder.Entity<tblGoal>().HasData(
                new tblGoal
                {
                    Id = goalId1,
                    ProjectId = projectId1,
                    Title = "Q1 Goals",
                    Description = "First quarter objectives",
                    DueDate = DateTime.UtcNow.AddMonths(3),
                    Progress = 0,
                    CreatedAt = DateTime.UtcNow
                },
                new tblGoal
                {
                    Id = goalId2,
                    ProjectId = projectId2,
                    Title = "Q2 Goals",
                    Description = "Second quarter objectives",
                    DueDate = DateTime.UtcNow.AddMonths(6),
                    Progress = 0,
                    CreatedAt = DateTime.UtcNow
                }
            );

            // 4. Third Level Dependencies

            // Columns
            var columnTodo1 = Guid.NewGuid();
            var columnInProgress1 = Guid.NewGuid();
            var columnDone1 = Guid.NewGuid();

            modelBuilder.Entity<tblColumn>().HasData(
                new tblColumn
                {
                    Id = columnTodo1,
                    BoardId = boardId1,
                    Name = "To Do",
                    Order = 1,
                    CreatedAt = DateTime.UtcNow
                },
                new tblColumn
                {
                    Id = columnInProgress1,
                    BoardId = boardId1,
                    Name = "In Progress",
                    Order = 2,
                    CreatedAt = DateTime.UtcNow
                },
                new tblColumn
                {
                    Id = columnDone1,
                    BoardId = boardId1,
                    Name = "Done",
                    Order = 3,
                    CreatedAt = DateTime.UtcNow
                }
            );

            // Milestones
            var milestoneId1 = Guid.NewGuid();
            var milestoneId2 = Guid.NewGuid();

            modelBuilder.Entity<tblMilestone>().HasData(
                new tblMilestone
                {
                    Id = milestoneId1,
                    GoalId = goalId1,
                    Title = "Sprint 1",
                    Description = "First sprint milestone",
                    DueDate = DateTime.UtcNow.AddMonths(1),
                    MilestoneStatusId = statusNotStarted,
                    CreatedAt = DateTime.UtcNow
                },
                new tblMilestone
                {
                    Id = milestoneId2,
                    GoalId = goalId1,
                    Title = "Sprint 2",
                    Description = "Second sprint milestone",
                    DueDate = DateTime.UtcNow.AddMonths(2),
                    MilestoneStatusId = statusNotStarted,
                    CreatedAt = DateTime.UtcNow
                }
            );

            // 5. Tasks (Most Dependencies)
            modelBuilder.Entity<tblTask>().HasData(
                new tblTask
                {
                    Id = Guid.NewGuid(),
                    ColumnId = columnTodo1,
                    MilestoneId = milestoneId1,  // Optional
                    AssigneeId = userId1,        // Optional
                    TagId = tagFeature,          // Optional
                    PriorityId = priorityMedium,
                    Title = "Initial Setup",
                    Description = "Set up project infrastructure",
                    DueDate = DateTime.UtcNow.AddDays(7),
                    Order = 1,
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow
                },
                new tblTask
                {
                    Id = Guid.NewGuid(),
                    ColumnId = columnInProgress1,
                    MilestoneId = milestoneId1,  // Optional
                    AssigneeId = userId2,        // Optional
                    TagId = tagBug,              // Optional
                    PriorityId = priorityHigh,
                    Title = "Fix Login Bug",
                    Description = "Resolve authentication issues",
                    DueDate = DateTime.UtcNow.AddDays(3),
                    Order = 1,
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow
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
