using AimHigh.BL.Models;
using AimHigh.PL.Data;
using AimHigh.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AimHigh.BL
{
    public class LoginFailureException : Exception
    {
        public LoginFailureException() : base("Cannot log in with these credentials.  Your IP address has been saved.")
        {
        }

        public LoginFailureException(string message) : base(message)
        {
        }
    }

    public class UserManager : GenericManager<tblUser>
    {
        public UserManager(DbContextOptions<AimHighEntities> options) : base(options) { }


        private string GetHash(string Password)
        {
            using (var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }

        public void Seed()
        {
            List<User> users = Load();

            foreach (User user in users)
            {
                if (user.Password.Length != 28)
                {
                    Update(user);
                }
            }

            if (users.Count == 0)
            {
                // Hardcord a couple of users with hashed passwords
                Insert(new User { Email = "gvallejos@gmail.com", FirstName = "Gerald", LastName = "Vallejos", Password = "maple" });
                Insert(new User { Email = "kvicchiollo@gmail.com", FirstName = "Ken", LastName = "Vicchiollo", Password = "password" });
            }
        }

        public bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Email))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (AimHighEntities dc = new AimHighEntities(options))
                        {
                            tblUser userrow = dc.tblUsers.FirstOrDefault(u => u.Email == user.Email);

                            if (userrow != null)
                            {
                                // check the password
                                if (userrow.Password == GetHash(user.Password))
                                {
                                    // Login was successfull
                                    user.Id = userrow.Id;
                                    user.FirstName = userrow.FirstName;
                                    user.LastName = userrow.LastName;
                                    user.Email = userrow.Email;
                                    user.Password = userrow.Password;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException("Cannot log in with these credentials.  Your IP address has been saved.");
                                }
                            }
                            else
                            {
                                throw new Exception("User could not be found.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Password was not set.");
                    }
                }
                else
                {
                    throw new Exception("User Name was not set.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<User> Load()
        {
            try
            {
                List<User> users = new List<User>();

                base.Load()
                    .ForEach(u => users
                    .Add(new User
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,

                        Password = u.Password,
                        Email = u.Email
                    }));

                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User LoadById(Guid id)
        {
            try
            {
                tblUser row = base.LoadById(id);

               if(row != null)
                {
                    User user = new User
                    {
                        Id = row.Id,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        Password = row.Password,
                        Email = row.Email

                    };
                    return user;

                }
               else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Insert(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (AimHighEntities dc = new AimHighEntities(options))
                {
                    // Check if email already exists - do not allow ....
                    bool inuse = dc.tblUsers.Any(u => u.Email.Trim().ToUpper() == user.Email.Trim().ToUpper());

                    if (inuse && rollback == false)
                    {
                        throw new Exception("This Email already exists.");
                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        tblUser newUser = new tblUser();

                        newUser.Id = Guid.NewGuid();
                        newUser.FirstName = user.FirstName.Trim();
                        newUser.LastName = user.LastName.Trim();
                        newUser.Email = user.Email.Trim();
                        newUser.Password = GetHash(user.Password.Trim());

                        user.Id = newUser.Id;

                        dc.tblUsers.Add(newUser);

                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int Update(User user, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (AimHighEntities dc = new AimHighEntities())
                {
                    // Check if username already exists - do not allow ....
                    tblUser existingUser = dc.tblUsers.Where(u => u.Email.Trim().ToUpper() == user.Email.Trim().ToUpper()).FirstOrDefault();

                    if (existingUser != null && existingUser.Id != user.Id && rollback == false)
                    {
                        throw new Exception("This User Name already exists.");
                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        tblUser upDateRow = dc.tblUsers.FirstOrDefault(r => r.Id == user.Id);

                        if (upDateRow != null)
                        {
                            upDateRow.FirstName = user.FirstName.Trim();
                            upDateRow.LastName = user.LastName.Trim();
                            upDateRow.Email = user.Email.Trim();
                            upDateRow.Password = GetHash(user.Password.Trim());

                            dc.tblUsers.Update(upDateRow);

                            // Commit the changes and get the number of rows affected
                            results = dc.SaveChanges();

                            if (rollback) transaction.Rollback();
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
                        }
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (AimHighEntities dc = new AimHighEntities())
                {
                    // Check if user is associated with an exisiting order - do not allow delete ....
                    //bool inuse = dc.tblOrders.Any(o => o.UserId == id);

                   /* if (inuse)
                    {
                        throw new Exception("This user is associated with an existing order and therefore cannot be deleted.");
                    }
                    else
                    {*/
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        tblUser deleteRow = dc.tblUsers.FirstOrDefault(r => r.Id == id);

                        if (deleteRow != null)
                        {
                            dc.tblUsers.Remove(deleteRow);

                            // Commit the changes and get the number of rows affected
                            results = dc.SaveChanges();

                            if (rollback) transaction.Rollback();
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
                        }
                    
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
