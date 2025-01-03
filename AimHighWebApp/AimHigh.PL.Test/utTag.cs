using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace AimHigh.PL.Test
{
    [TestClass]
    public class utTag : utBase<tblTag>
    {
        private tblTag CreateValidTag()
        {
            return new tblTag
            {
                Id = Guid.NewGuid(),
                Name = "Test Tag",
                Color = "#FF0000"
            };
        }

        [TestMethod]
        public void Load_ShouldReturnSeededTags()
        {
            var tags = base.LoadTest();
            Assert.IsTrue(tags.Any());
        }

        [TestMethod]
        public void Insert_ValidTag_ShouldSucceed()
        {
            var tag = CreateValidTag();
            int rowsAffected = base.InsertTest(tag);
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void Update_ValidTag_ShouldSucceed()
        {
            var tag = CreateValidTag();
            base.InsertTest(tag);

            tag.Name = "Updated Tag";
            int rowsAffected = base.UpdateTest(tag);
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void Delete_TagWithNoTasks_ShouldSucceed()
        {
            var tag = CreateValidTag();
            base.InsertTest(tag);

            int rowsAffected = base.DeleteTest(tag);
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void Delete_TagWithTasks_ShouldSucceed()
        {
            // Arrange
            // 1. Create a user (needed for project)
            var user = new tblUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "User",
                Email = "test@test.com",
                Password = "password123"
            };
            dc.tblUsers.Add(user);

            // 2. Create a project
            var project = new tblProject
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Name = "Test Project",
                Description = "Test Description",
                CreatedAt = DateTime.UtcNow
            };
            dc.tblProjects.Add(project);

            // 3. Create a board
            var board = new tblBoard
            {
                Id = Guid.NewGuid(),
                ProjectId = project.Id,
                Name = "Test Board",
                Description = "Test Description",
                CreatedAt = DateTime.UtcNow
            };
            dc.tblBoards.Add(board);

            // 4. Create a column
            var column = new tblColumn
            {
                Id = Guid.NewGuid(),
                BoardId = board.Id,
                Name = "Test Column",
                Order = 1,
                CreatedAt = DateTime.UtcNow
            };
            dc.tblColumns.Add(column);

            // 5. Create a priority (required for task)
            var priority = new tblPriority
            {
                Id = Guid.NewGuid(),
                Name = "Test Priority",
                Description = "Test Description",
                DisplayOrder = 1,
                IsActive = true,
                ColorCode = "#FF0000"
            };
            dc.tblPriorities.Add(priority);

            // 6. Create the tag we want to test
            var tag = CreateValidTag();
            base.InsertTest(tag);

            // Save everything so far
            dc.SaveChanges();

            // 7. Create task with proper relationships
            var task = new tblTask
            {
                Id = Guid.NewGuid(),
                ColumnId = column.Id,  // Using valid column
                Title = "Test Task",
                Description = "Test Description",
                DueDate = DateTime.UtcNow,
                Order = 1,
                CreatedAt = DateTime.UtcNow,
                TagId = tag.Id,
                PriorityId = priority.Id  // Required priority
            };
            dc.tblTasks.Add(task);
            dc.SaveChanges();

            // Act
            int rowsAffected = base.DeleteTest(tag);

            // Assert
            Assert.AreEqual(2, rowsAffected);

            // Verify task still exists but with null TagId
            var updatedTask = dc.tblTasks.Find(task.Id);
            Assert.IsNotNull(updatedTask);
            Assert.IsNull(updatedTask.TagId);
        }
    }

}