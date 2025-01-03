using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace AimHigh.PL.Test
{
    [TestClass]
    public class utUser : utBase<tblUser>
    {
        private tblUser CreateValidUser()
        {
            return new tblUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "User",
                Email = "test.user@example.com",
                Password = "TestPass123"
            };
        }

        [TestMethod]
        public void Load_ShouldReturnSeededUsers()
        {
            // Arrange & Act
            var users = base.LoadTest();

            // Assert
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Any());
        }

        [TestMethod]
        public void Insert_ValidUser_ShouldSucceed()
        {
            // Arrange
            var newUser = CreateValidUser();

            // Act
            int rowsAffected = base.InsertTest(newUser);

            // Assert
            Assert.AreEqual(1, rowsAffected);
            var savedUser = dc.tblUsers.Find(newUser.Id);
            Assert.IsNotNull(savedUser);
            Assert.AreEqual(newUser.Email, savedUser.Email);
        }

        [TestMethod]
        public void Insert_DuplicateEmail_ShouldFail()
        {
            // Arrange
            var user1 = CreateValidUser();
            base.InsertTest(user1);

            var user2 = CreateValidUser();
            user2.Id = Guid.NewGuid();
            user2.Email = user1.Email; // Same email

            // Act & Assert
            Assert.ThrowsException<DbUpdateException>(() => base.InsertTest(user2));
        }

        [TestMethod]
        public void Update_ValidUser_ShouldSucceed()
        {
            // Arrange
            var user = CreateValidUser();
            base.InsertTest(user);

            // Act
            string newFirstName = "Updated";
            user.FirstName = newFirstName;
            int rowsAffected = base.UpdateTest(user);

            // Assert
            Assert.AreEqual(1, rowsAffected);
            var updatedUser = dc.tblUsers.Find(user.Id);
            Assert.AreEqual(newFirstName, updatedUser.FirstName);
        }

        [TestMethod]
        public void Delete_ExistingUser_ShouldSucceed()
        {
            // Arrange
            var user = CreateValidUser();
            base.InsertTest(user);

            // Act
            int rowsAffected = base.DeleteTest(user);

            // Assert
            Assert.AreEqual(1, rowsAffected);
            var deletedUser = dc.tblUsers.Find(user.Id);
            Assert.IsNull(deletedUser);
        }


        //it tests that we can't delete a user that has associated projects
        [TestMethod]
        public void Delete_UserWithProjects_ShouldFail()
        {
            // Arrange
            var user = CreateValidUser();
            base.InsertTest(user);

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

            // Act & Assert
            var exception = Assert.ThrowsException<InvalidOperationException>(() =>
                base.DeleteTest(user)
            );

            // Verify it's the correct error message about required relationships
            Assert.IsTrue(exception.Message.Contains("relationship is either marked as required"),
                "Expected error about required relationship");
        }
    }
}