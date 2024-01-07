using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiWithSQLConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public RegionController(DatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: api/region
        [HttpGet]
        public ActionResult<IEnumerable<Region>> GetAllRegions()
        {
            return _dbContext.Regions.ToList();
        }

        // GET: api/region/5
        [HttpGet("{id}")]
        public ActionResult<Region> GetRegionById(int id)
        {
            var region = _dbContext.Regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }
            return region;
        }

        // POST: api/region
        [HttpPost]
        public ActionResult<Region> PostRegion([FromBody] Region region)
        {
            _dbContext.Regions.Add(region);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetRegionById), new { id = region.RegionID }, region);
        }

        // PUT: api/region/5
        [HttpPut("{id}")]
        public IActionResult UpdateRegion(int id, [FromBody] Region region)
        {
            if (id != region.RegionID)
            {
                return BadRequest();
            }

            _dbContext.Entry(region).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Regions.Any(r => r.RegionID == id))
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

        // DELETE: api/region/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRegion(int id)
        {
            var region = _dbContext.Regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }

            _dbContext.Regions.Remove(region);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}