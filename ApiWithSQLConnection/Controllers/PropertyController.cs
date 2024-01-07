using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiWithSQLConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public PropertyController(DatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: api/property
        [HttpGet]
        public ActionResult<IEnumerable<Property>> GetAllProperties()
        {
            return _dbContext.Properties.ToList();
        }

        // GET: api/property/5
        [HttpGet("{id}")]
        public ActionResult<Property> GetPropertyById(int id)
        {
            var property = _dbContext.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }
            return property;
        }

        // POST: api/property
        [HttpPost]
        public ActionResult<Property> PostProperty([FromBody] Property property)
        {
            _dbContext.Properties.Add(property);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetPropertyById), new { id = property.PropertyID }, property);
        }

        // PUT: api/property/5
        [HttpPut("{id}")]
        public IActionResult UpdateProperty(int id, [FromBody] Property property)
        {
            if (id != property.PropertyID)
            {
                return BadRequest();
            }

            _dbContext.Entry(property).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Properties.Any(p => p.PropertyID == id))
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

        // DELETE: api/property/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(int id)
        {
            var property = _dbContext.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }

            _dbContext.Properties.Remove(property);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}