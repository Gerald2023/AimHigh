/*using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace AimHigh.PL.Test
{

    [TestClass]
    public class utBoard : utBase<tblBoard>
    {
        public tblBoard CreateValidBoard()
        {
            // First create required User and Project
            var user = new tblUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "User",
                Email = "test@test.com",
                Password = "password123"
            };
            dc.tblUsers.Add(user);

            var project = new tblProject
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Name = "Test Project",
                Description = "Test Description",
                CreatedAt = DateTime.UtcNow
            };
            dc.tblProjects.Add(project);
            dc.SaveChanges();

            return new tblBoard
            {
                Id = Guid.NewGuid(),
                ProjectId = project.Id,
                Name = "Test Board",
                Description = "Test Board Description",
                CreatedAt = DateTime.UtcNow
            };
        }

        [TestMethod]
        public void Load_ShouldReturnBoards()
        {
            var boards = base.LoadTest();
            Assert.IsTrue(boards.Any());
        }

        [TestMethod]
        public void Insert_ValidBoard_ShouldSucceed()
        {
            var board = CreateValidBoard();
            int rowsAffected = base.InsertTest(board);
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void Delete_BoardWithColumns_ShouldCascade()
        {
            // Arrange
            var board = CreateValidBoard();
            base.InsertTest(board);

            var column = new tblColumn
            {
                Id = Guid.NewGuid(),
                BoardId = board.Id,
                Name = "To Do",
                Order = 1,
                CreatedAt = DateTime.UtcNow
            };
            dc.tblColumns.Add(column);
            dc.SaveChanges();

            // Act
            int rowsAffected = base.DeleteTest(board);

            // Assert
            Assert.AreEqual(1, rowsAffected);
            Assert.IsNull(dc.tblColumns.Find(column.Id), "Column should be deleted with board");
        }
    }
}*/