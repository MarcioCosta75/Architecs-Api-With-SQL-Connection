using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiWithSQLConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DecadesController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public DecadesController(DatabaseContext context) {
            _dbContext = context;
        }

        // GET: api/decades
        [HttpGet]
        public ActionResult<IEnumerable<Decade>> GetAllDecades() {
            return _dbContext.Decades.ToList();
        }

        // GET: api/decades/5
        [HttpGet("{decade}")]
        public ActionResult<Decade> GetDecade(int decade) {
            var decadeData = _dbContext.Decades.Find(decade);
            if (decadeData == null) {
                return NotFound();
            }
            return decadeData;
        }

        // POST: api/decades
        [HttpPost]
        public ActionResult<Decade> PostDecade([FromBody]Decade decade) {
            _dbContext.Decades.Add(decade);
            _dbContext.SaveChanges();

            return CreatedAtAction("GetDecade", new { decade = decade.DecadeValue }, decade);
        }

        // PUT: api/decades/5
        [HttpPut("{decade}")]
        public IActionResult UpdateDecade(int decade, [FromBody]Decade updatedDecade) {
            if (decade != updatedDecade.DecadeValue) {
                return BadRequest();
            }

            _dbContext.Entry(updatedDecade).State = EntityState.Modified;
            try {
                _dbContext.SaveChanges();
            } catch (DbUpdateConcurrencyException) {
                if (!_dbContext.Decades.Any(d => d.DecadeValue == decade)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/decades/5
        [HttpDelete("{decade}")]
        public IActionResult DeleteDecade(int decade) {
            var decadeData = _dbContext.Decades.Find(decade);
            if (decadeData == null) {
                return NotFound();
            }

            _dbContext.Decades.Remove(decadeData);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
