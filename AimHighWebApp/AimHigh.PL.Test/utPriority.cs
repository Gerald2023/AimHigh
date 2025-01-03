using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace AimHigh.PL.Test
{

    [TestClass]
    public class utPriority : utBase<tblPriority>
    {
        private tblPriority CreateValidPriority()
        {
            return new tblPriority
            {
                Id = Guid.NewGuid(),
                Name = "Test Priority",
                Description = "Test Description",
                DisplayOrder = 1,
                IsActive = true,
                ColorCode = "#FF0000"
            };
        }

        [TestMethod]
        public void Load_ShouldReturnSeededPriorities()
        {
            var priorities = base.LoadTest();
            Assert.IsTrue(priorities.Any());
        }

        [TestMethod]
        public void Insert_ValidPriority_ShouldSucceed()
        {
            var priority = CreateValidPriority();
            int rowsAffected = base.InsertTest(priority);
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void Insert_DuplicateName_ShouldFail()
        {
            var priority1 = CreateValidPriority();
            base.InsertTest(priority1);

            var priority2 = CreateValidPriority();
            Assert.ThrowsException<DbUpdateException>(() => base.InsertTest(priority2));
        }

        [TestMethod]
        public void Update_ValidPriority_ShouldSucceed()
        {
            var priority = CreateValidPriority();
            base.InsertTest(priority);

            priority.Name = "Updated Priority";
            int rowsAffected = base.UpdateTest(priority);
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void Delete_PriorityWithNoTasks_ShouldSucceed()
        {
            var priority = CreateValidPriority();
            base.InsertTest(priority);

            int rowsAffected = base.DeleteTest(priority);
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void Delete_PriorityWithTasks_ShouldFail()
        {
            var priority = CreateValidPriority();
            base.InsertTest(priority);

            var task = new tblTask
            {
                Id = Guid.NewGuid(),
                ColumnId = Guid.NewGuid(),
                Title = "Test Task",
                Description = "Test Description",
                DueDate = DateTime.UtcNow,
                Order = 1,
                CreatedAt = DateTime.UtcNow,
                PriorityId = priority.Id
            };
            dc.tblTasks.Add(task);
            dc.SaveChanges();

            Assert.ThrowsException<InvalidOperationException>(() => base.DeleteTest(priority));
        }
    }
}