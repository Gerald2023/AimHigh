namespace AimHigh.PL.Test
{
    [TestClass]
    public class utUser : utBase<tblUser>
    {

        [TestMethod]
        public void LoadTest()
        {
            Assert.IsTrue(base.LoadTest().Count() > 0);

        }

        [TestMethod]
        public void InsertTest()
        {
            tblUser newRow = new tblUser();

            newRow.Id = Guid.NewGuid();
            newRow.FirstName = "Joe";
            newRow.LastName = "Billings";
            newRow.Password = "YYYYY";
            newRow.Email = "xxxx@gmail.com";

            dc.tblUsers.Add(newRow);
            int rowsAffected = dc.SaveChanges();

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblUser row = base.LoadTest().FirstOrDefault(x => x.FirstName == "Gerald");

            if (row != null)
            {
                row.FirstName = "Test";
                int rowsAffected = UpdateTest(row);

                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {

            tblUser row = base.LoadTest().FirstOrDefault(x => x.FirstName == "Gerald");

            if (row != null)
            {
                dc.tblUsers.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}