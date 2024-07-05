using AimHigh.BL.Models;
using AimHigh.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AimHigh.BL;
using Microsoft.SqlServer.Server;
using Task = AimHigh.BL.Models.Task;


namespace AimHigh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {



        private readonly ILogger<TaskController> logger;
        private readonly DbContextOptions<AimHighEntities> options;

        public TaskController(ILogger<TaskController> logger,
                                DbContextOptions<AimHighEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!!!");
        }

        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return new TaskManager(options).Load();
        }

        [HttpGet("{id}")]
        public Task Get(Guid id)
        {
            return new TaskManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Task task, bool rollback = false)
        {
            try
            {
                return new TaskManager(options).Insert(task, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Task task, bool rollback = false)
        {
            try
            {
                return new TaskManager(options).Update(task, rollback);
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
                return new TaskManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
