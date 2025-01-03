using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace AimHigh.PL.Test
{
    [TestClass]
    public class utTask : utBase<tblTask>
    {
        [TestMethod]
        public void LoadTest()
        {
            // Tests loading of seeded data
            int expected = 2;  // Based on your seed data
            var tasks = base.LoadTest();
            Assert.AreEqual(expected, tasks.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            // First get existing Column and Priority from seed data
            var existingColumn = dc.tblColumns.FirstOrDefault();
            var existingPriority = dc.tblPriorities.FirstOrDefault();

            // Make sure we have the required data
            Assert.IsNotNull(existingColumn, "No Column found in database");
            Assert.IsNotNull(existingPriority, "No Priority found in database");

            tblTask newRow = new tblTask();
            newRow.Id = Guid.NewGuid();
            newRow.ColumnId = existingColumn.Id;        // Use existing Column ID
            newRow.PriorityId = existingPriority.Id;    // Use existing Priority ID
            newRow.Title = "Test Title";
            newRow.Description = "Test Description";
            newRow.DueDate = new DateTime(2025, 1, 3);
            newRow.Order = 1;
            newRow.CreatedAt = DateTime.UtcNow;

            // Optional fields can be null
            newRow.MilestoneId = null;
            newRow.AssigneeId = null;
            newRow.TagId = null;

            int rowsAffected = InsertTest(newRow);
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // Get first task from seeded data
            tblTask row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.Title = "Updated Title";
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Get first task from seeded data
            tblTask row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }
    }

}