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
    public class MilestoneController : ControllerBase
    {



        private readonly ILogger<MilestoneController> logger;
        private readonly DbContextOptions<AimHighEntities> options;

        public MilestoneController(ILogger<MilestoneController> logger,
                                DbContextOptions<AimHighEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!!!");
        }

        [HttpGet]
        public IEnumerable<Milestone> Get()
        {
            return new MilestoneManager(options).Load();
        }

        [HttpGet("{id}")]
        public Milestone Get(Guid id)
        {
            return new MilestoneManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Milestone milestone, bool rollback = false)
        {
            try
            {
                return new MilestoneManager(options).Insert(milestone, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Milestone milestone, bool rollback = false)
        {
            try
            {
                return new MilestoneManager(options).Update(milestone, rollback);
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
                return new MilestoneManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
