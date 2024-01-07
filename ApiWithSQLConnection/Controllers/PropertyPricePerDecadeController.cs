using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiWithSQLConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyPricePerDecadeController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public PropertyPricePerDecadeController(DatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: api/propertypriceperdecade
        [HttpGet]
        public ActionResult<IEnumerable<PropertyPricePer_Decade>> GetAllPropertyPricesPerDecade()
        {
            return _dbContext.PropertyPricePer_Decades.ToList();
        }

        // GET: api/propertypriceperdecade/{propertyId}/{decade}
        [HttpGet("{propertyId}/{decade}")]
        public ActionResult<PropertyPricePer_Decade> GetPropertyPricePerDecade(int propertyId, int decade)
        {
            var propertyPricePerDecade = _dbContext.PropertyPricePer_Decades
                .FirstOrDefault(pppd => pppd.PropertyID == propertyId && pppd.Decade == decade);

            if (propertyPricePerDecade == null)
            {
                return NotFound();
            }
            return propertyPricePerDecade;
        }

        // POST: api/propertypriceperdecade
        [HttpPost]
        public ActionResult<PropertyPricePer_Decade> PostPropertyPricePerDecade([FromBody] PropertyPricePer_Decade propertyPricePerDecade)
        {
            _dbContext.PropertyPricePer_Decades.Add(propertyPricePerDecade);
            _dbContext.SaveChanges();

            return CreatedAtAction("GetPropertyPricePerDecade",
                new { propertyId = propertyPricePerDecade.PropertyID, decade = propertyPricePerDecade.Decade },
                propertyPricePerDecade);
        }

        // PUT: api/propertypriceperdecade/{propertyId}/{decade}
        [HttpPut("{propertyId}/{decade}")]
        public IActionResult UpdatePropertyPricePerDecade(int propertyId, int decade, [FromBody] PropertyPricePer_Decade propertyPricePerDecade)
        {
            if (propertyId != propertyPricePerDecade.PropertyID || decade != propertyPricePerDecade.Decade)
            {
                return BadRequest();
            }

            _dbContext.Entry(propertyPricePerDecade).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.PropertyPricePer_Decades.Any(pppd => pppd.PropertyID == propertyId && pppd.Decade == decade))
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

        // DELETE: api/propertypriceperdecade/{propertyId}/{decade}
        [HttpDelete("{propertyId}/{decade}")]
        public IActionResult DeletePropertyPricePerDecade(int propertyId, int decade)
        {
            var propertyPricePerDecade = _dbContext.PropertyPricePer_Decades
                .FirstOrDefault(pppd => pppd.PropertyID == propertyId && pppd.Decade == decade);

            if (propertyPricePerDecade == null)
            {
                return NotFound();
            }

            _dbContext.PropertyPricePer_Decades.Remove(propertyPricePerDecade);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}