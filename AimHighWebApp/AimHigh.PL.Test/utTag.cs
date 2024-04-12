namespace AimHigh.PL.Test
{
    [TestClass]
    public class utTag : utBase<tblTag>
    {

        [TestMethod]
        public void LoadTest()
        {
            int expected = 2;
            var formats = base.LoadTest();
            Assert.AreEqual(expected, formats.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = base.InsertTest(new tblTag
            {
                Id = Guid.NewGuid(),
                Description = "XXXXX"
            });
            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod]
        public void UpdateTest()
        {
            tblTag row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

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

            tblTag row = base.LoadTest().FirstOrDefault(x => x.Description == "Other");

            if (row != null)
            {
                dc.tblTags.Remove(row);
                int rowsAffected = dc.SaveChanges();

                Assert.IsTrue(rowsAffected == 1);
            }

        }
    }
}