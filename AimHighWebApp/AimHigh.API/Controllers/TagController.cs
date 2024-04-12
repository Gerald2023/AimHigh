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
    public class TagController : ControllerBase
    {



        private readonly ILogger<TagController> logger;
        private readonly DbContextOptions<AimHighEntities> options;

        public TagController(ILogger<TagController> logger,
                                DbContextOptions<AimHighEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!!!");
        }

        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            return new TagManager(options).Load();
        }

        [HttpGet("{id}")]
        public Tag Get(Guid id)
        {
            return new TagManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Tag format, bool rollback = false)
        {
            try
            {
                return new TagManager(options).Insert(format, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Tag format, bool rollback = false)
        {
            try
            {
                return new TagManager(options).Update(format, rollback);
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
                return new TagManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
