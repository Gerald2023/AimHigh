//using Microsoft.Data.SqlClient;
//using static System.Net.Mime.MediaTypeNames;

//namespace AimHigh.PL.Test
//{

//    [TestClass]
//    public class utColumn : utBase<tblColumn>
//    {
//        private tblBoard _testBoard;

//        private tblColumn CreateValidColumn()
//        {
//            if (_testBoard == null)
//            {
//                var board = new utBoard().CreateValidBoard();
//                new utBase<tblBoard>().InsertTest(board); // Fix: Insert the board using utBase<tblBoard>
//                _testBoard = board;
//            }

//            return new tblColumn
//            {
//                Id = Guid.NewGuid(),
//                BoardId = _testBoard.Id,
//                Name = "Test Column",
//                Order = 1,
//                CreatedAt = DateTime.UtcNow
//            };
//        }

//        [TestMethod]
//        public void Insert_ValidColumn_ShouldSucceed()
//        {
//            var column = CreateValidColumn();
//            int rowsAffected = base.InsertTest(column);
//            Assert.AreEqual(1, rowsAffected);
//        }

//        [TestMethod]
//        public void Update_ColumnOrder_ShouldSucceed()
//        {
//            var column = CreateValidColumn();
//            base.InsertTest(column);

//            column.Order = 2;
//            int rowsAffected = base.UpdateTest(column);
//            Assert.AreEqual(1, rowsAffected);
//        }

//        [TestMethod]
//        public void Delete_ColumnWithTasks_ShouldCascade()
//        {
//            // Arrange
//            var column = CreateValidColumn();
//            base.InsertTest(column);

//            var priority = new tblPriority
//            {
//                Id = Guid.NewGuid(),
//                Name = "Test Priority",
//                DisplayOrder = 1,
//                IsActive = true,
//                ColorCode = "#FF0000"
//            };
//            dc.tblPriorities.Add(priority);

//            var task = new tblTask
//            {
//                Id = Guid.NewGuid(),
//                ColumnId = column.Id,
//                Title = "Test Task",
//                Description = "Test Description",
//                DueDate = DateTime.UtcNow,
//                Order = 1,
//                CreatedAt = DateTime.UtcNow,
//                PriorityId = priority.Id
//            };
//            dc.tblTasks.Add(task);
//            dc.SaveChanges();

//            // Act
//            int rowsAffected = base.DeleteTest(column);

//            // Assert
//            Assert.AreEqual(1, rowsAffected);
//            Assert.IsNull(dc.tblTasks.Find(task.Id), "Task should be deleted with column");
//        }
//    }
//}