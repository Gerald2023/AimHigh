namespace AimHigh.PL.Test
{
    [TestClass]
    public class utGoal : utBase<tblGoal>
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
            int rowsAffected = base.InsertTest(new tblGoal
            {
                Id = Guid.NewGuid(),
                UserId = dc.tblUsers.FirstOrDefault().Id, // This retrieves the Id of an existing user from the tblUsers table
                Title = "XXXXX",
                Description = "XXXXX",
                Date = DateTime.Now,
                Progress = 0.5

            }); ;
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblGoal row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

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

            tblGoal row = base.LoadTest().FirstOrDefault(x => x.Title == "Learn ASP.NET Core");

            if (row != null)
            {
                dc.tblGoals.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

            

        }


    }
}