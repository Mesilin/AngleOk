using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AngleOk.Web.Controllers.Api
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        AngleOkContext db;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="db"></param>
        /// <param name="logger"></param>
        public PersonController(AngleOkContext db, ILogger<PersonController> logger)
        {
            _logger = logger;
            this.db = db;
        }

        /// <summary>
        /// Получить все записи из таблицы "Люди"
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get() => await db.Persons.ToListAsync();

        /// <summary>
        /// Получить из таблицы "Люди" запись с идентификатором id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (id == default)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var person = await db.Persons.FirstOrDefaultAsync(x => x.PersonId == id);
            if (person == null)
                return NotFound();
            return new ObjectResult(person);
        }

        /// <summary>
        /// Добавить в таблицу "Люди" новую запись
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Post(Person person)
        {
            try
            {
                if (person == null)
                    return BadRequest();

                db.Persons.Add(person);
                await db.SaveChangesAsync();
                return Ok(person.PersonId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Изменить запись с идентификатором "id" в таблице "Люди" 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Guid>> Put(Person person)
        {
            if (person == null)
                return BadRequest();
            if (!db.Persons.Any(x => x.PersonId == person.PersonId))
                return NotFound();

            db.Update(person);
            await db.SaveChangesAsync();
            return Ok(person.PersonId);
        }

        /// <summary>
        /// Удалить из таблицы "Люди" запись с идентификатором "id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> Delete(Guid id)
        {
            if (id == default)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var person = db.Persons.FirstOrDefault(x => x.PersonId == id);
            if (person == null)
                return NotFound();
            
            db.Persons.Remove(person);
            await db.SaveChangesAsync();
            return Ok(person);
        }
    }
}
