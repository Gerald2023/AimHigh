namespace AimHigh.PL.Test
{
    [TestClass]
    public class utMilestone : utBase<tblMilestone>
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 2;
            var goals = base.LoadTest();
            Assert.AreEqual(expected, goals.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = base.InsertTest(new tblMilestone
            {
                Id = Guid.NewGuid(),
                GoalId = dc.tblGoals.FirstOrDefault().Id, // This retrieves the Id of an existing user from the tblUsers table
                Title = "XXXXX",
                Description = "XXXXX",
                DueDate = DateTime.Now,
                Status = "Pending"

            }); ;
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblMilestone row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            if (row != null)
            {
                row.Description = "YYYY";
                int rowsAffected = dc.SaveChanges();

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {

            tblMilestone row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            if (row != null)
            {
                dc.tblMilestones.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}