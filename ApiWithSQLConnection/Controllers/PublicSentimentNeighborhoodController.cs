using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiWithSQLConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicSentimentNeighborhoodController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public PublicSentimentNeighborhoodController(DatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: api/publicsentimentneighborhood
        [HttpGet]
        public ActionResult<IEnumerable<PublicSentiment_Neighborhood>> GetAllPublicSentimentsNeighborhood()
        {
            return _dbContext.PublicSentiment_Neighborhoods.ToList();
        }

        // GET: api/publicsentimentneighborhood/5
        [HttpGet("{id}")]
        public ActionResult<PublicSentiment_Neighborhood> GetPublicSentimentNeighborhoodById(int id)
        {
            var publicSentimentNeighborhood = _dbContext.PublicSentiment_Neighborhoods.Find(id);
            if (publicSentimentNeighborhood == null)
            {
                return NotFound();
            }
            return publicSentimentNeighborhood;
        }

        // POST: api/publicsentimentneighborhood
        [HttpPost]
        public ActionResult<PublicSentiment_Neighborhood> PostPublicSentimentNeighborhood([FromBody] PublicSentiment_Neighborhood publicSentimentNeighborhood)
        {
            _dbContext.PublicSentiment_Neighborhoods.Add(publicSentimentNeighborhood);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetPublicSentimentNeighborhoodById), new { id = publicSentimentNeighborhood.SentimentID }, publicSentimentNeighborhood);
        }

        // PUT: api/publicsentimentneighborhood/5
        [HttpPut("{id}")]
        public IActionResult UpdatePublicSentimentNeighborhood(int id, [FromBody] PublicSentiment_Neighborhood publicSentimentNeighborhood)
        {
            if (id != publicSentimentNeighborhood.SentimentID)
            {
                return BadRequest();
            }

            _dbContext.Entry(publicSentimentNeighborhood).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.PublicSentiment_Neighborhoods.Any(psn => psn.SentimentID == id))
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

        // DELETE: api/publicsentimentneighborhood/5
        [HttpDelete("{id}")]
        public IActionResult DeletePublicSentimentNeighborhood(int id)
        {
            var publicSentimentNeighborhood = _dbContext.PublicSentiment_Neighborhoods.Find(id);
            if (publicSentimentNeighborhood == null)
            {
                return NotFound();
            }

            _dbContext.PublicSentiment_Neighborhoods.Remove(publicSentimentNeighborhood);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}