using AimHigh.BL;
using AimHigh.BL.Models;
using AimHigh.PL.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace AimHigh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbContextOptions<AimHighEntities> options;

        public UserController(ILogger<UserController> logger,

        DbContextOptions<AimHighEntities> options)
        {
                    this.options = options;
                    //this.logger = logger;
                    //logger.LogWarning("I was here!!!");
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new UserManager(options).Load();
        }

        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            return new UserManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] User user, bool rollback = false)
        {
            try
            {
                return new UserManager(options).Insert(user, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] User user, bool rollback = false)
        {
            try
            {
                return new UserManager(options).Update(user, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new UserManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
