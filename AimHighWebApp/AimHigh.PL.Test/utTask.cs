namespace AimHigh.PL.Test
{
    [TestClass]
    public class utTask : utBase<tblTask>
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 2;
            var tasks = base.LoadTest();
            Assert.AreEqual(expected, tasks.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = base.InsertTest(new tblTask
            {
                Id = Guid.NewGuid(),
                UserId = dc.tblUsers.FirstOrDefault().Id, // This retrieves the Id of an existing user from the tblUsers table
                MilestoneId = dc.tblMilestones.FirstOrDefault().Id, // This retrieves the Id of an existing milestone from the tblMilestones table
                Title = "XXXXX",
                Description = "XXXXX",
                Date = DateTime.Now,
                TagId = dc.tblTags.FirstOrDefault().Id, // This retrieves the Id of an existing tag from the tblTags table

            }); ;
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblTask row = base.LoadTest().FirstOrDefault(x => x.Description == "Read and complete exercises in Chapter 1 of the textbook.");

            if (row != null)
            {
                row.Description = "YYYY";
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
            else
            {
                // Fail the test if no task was found with the description "Other"
                Assert.Fail($"No task found with description");
            }
        }


        [TestMethod]
        public void DeleteTest()
        {

            tblTask row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            if (row != null)
            {
                dc.tblTasks.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}