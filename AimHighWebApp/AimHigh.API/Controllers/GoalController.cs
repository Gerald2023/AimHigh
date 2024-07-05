using AimHigh.BL.Models;
using AimHigh.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AimHigh.BL;
using Microsoft.SqlServer.Server;


namespace AimHigh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {



        private readonly ILogger<GoalController> logger;
        private readonly DbContextOptions<AimHighEntities> options;

        public GoalController(ILogger<GoalController> logger,
                                DbContextOptions<AimHighEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!!!");
        }

        [HttpGet]
        public IEnumerable<Goal> Get()
        {
            return new GoalManager(options).Load();
        }

        [HttpGet("{id}")]
        public Goal Get(Guid id)
        {
            return new GoalManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Goal goal, bool rollback = false)
        {
            try
            {
                return new GoalManager(options).Insert(goal, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Goal goal, bool rollback = false)
        {
            try
            {
                return new GoalManager(options).Update(goal, rollback);
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
                return new GoalManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
