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
    public class StatusController : ControllerBase
    {



        private readonly ILogger<StatusController> logger;
        private readonly DbContextOptions<AimHighEntities> options;

        public StatusController(ILogger<StatusController> logger,
                                DbContextOptions<AimHighEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!!!");
        }

        [HttpGet]
        public IEnumerable<Status> Get()
        {
            return new StatusManager(options).Load();
        }

        [HttpGet("{id}")]
        public Status Get(Guid id)
        {
            return new StatusManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Status format, bool rollback = false)
        {
            try
            {
                return new StatusManager(options).Insert(format, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Status format, bool rollback = false)
        {
            try
            {
                return new StatusManager(options).Update(format, rollback);
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
                return new StatusManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
