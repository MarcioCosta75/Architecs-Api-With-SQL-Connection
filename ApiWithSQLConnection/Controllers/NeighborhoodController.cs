using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiWithSQLConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NeighborhoodController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public NeighborhoodController(DatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: api/neighborhood
        [HttpGet]
        public ActionResult<IEnumerable<Neighborhood>> GetAllNeighborhoods()
        {
            return _dbContext.Neighborhoods.ToList();
        }

        // GET: api/neighborhood/5
        [HttpGet("{id}")]
        public ActionResult<Neighborhood> GetNeighborhoodById(int id)
        {
            var neighborhood = _dbContext.Neighborhoods.Find(id);
            if (neighborhood == null)
            {
                return NotFound();
            }
            return neighborhood;
        }

        // POST: api/neighborhood
        [HttpPost]
        public ActionResult<Neighborhood> PostNeighborhood([FromBody] Neighborhood neighborhood)
        {
            _dbContext.Neighborhoods.Add(neighborhood);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetNeighborhoodById), new { id = neighborhood.NeighborhoodID }, neighborhood);
        }

        // PUT: api/neighborhood/5
        [HttpPut("{id}")]
        public IActionResult UpdateNeighborhood(int id, [FromBody] Neighborhood neighborhood)
        {
            if (id != neighborhood.NeighborhoodID)
            {
                return BadRequest();
            }

            _dbContext.Entry(neighborhood).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Neighborhoods.Any(n => n.NeighborhoodID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/neighborhood/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNeighborhood(int id)
        {
            var neighborhood = _dbContext.Neighborhoods.Find(id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            _dbContext.Neighborhoods.Remove(neighborhood);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}