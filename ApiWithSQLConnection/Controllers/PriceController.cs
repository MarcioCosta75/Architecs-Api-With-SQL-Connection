using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiWithSQLConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public PriceController(DatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: api/price
        [HttpGet]
        public ActionResult<IEnumerable<Price>> GetAllPrices()
        {
            return _dbContext.Prices.ToList();
        }

        // GET: api/price/5
        [HttpGet("{id}")]
        public ActionResult<Price> GetPriceById(int id)
        {
            var price = _dbContext.Prices.Find(id);
            if (price == null)
            {
                return NotFound();
            }
            return price;
        }

        // POST: api/price
        [HttpPost]
        public ActionResult<Price> PostPrice([FromBody] Price price)
        {
            _dbContext.Prices.Add(price);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetPriceById), new { id = price.PropertyID }, price);
        }

        // PUT: api/price/5
        [HttpPut("{id}")]
        public IActionResult UpdatePrice(int id, [FromBody] Price price)
        {
            if (id != price.PropertyID)
            {
                return BadRequest();
            }

            _dbContext.Entry(price).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Prices.Any(p => p.PropertyID == id))
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

        // DELETE: api/price/5
        [HttpDelete("{id}")]
        public IActionResult DeletePrice(int id)
        {
            var price = _dbContext.Prices.Find(id);
            if (price == null)
            {
                return NotFound();
            }

            _dbContext.Prices.Remove(price);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}