using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiWithSQLConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicSentimentController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public PublicSentimentController(DatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: api/publicsentiment
        [HttpGet]
        public ActionResult<IEnumerable<PublicSentiment>> GetAllPublicSentiments()
        {
            return _dbContext.PublicSentiments.ToList();
        }

        // GET: api/publicsentiment/5
        [HttpGet("{id}")]
        public ActionResult<PublicSentiment> GetPublicSentimentById(int id)
        {
            var publicSentiment = _dbContext.PublicSentiments.Find(id);
            if (publicSentiment == null)
            {
                return NotFound();
            }
            return publicSentiment;
        }

        // POST: api/publicsentiment
        [HttpPost]
        public ActionResult<PublicSentiment> PostPublicSentiment([FromBody] PublicSentiment publicSentiment)
        {
            _dbContext.PublicSentiments.Add(publicSentiment);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetPublicSentimentById), new { id = publicSentiment.SentimentID }, publicSentiment);
        }

        // PUT: api/publicsentiment/5
        [HttpPut("{id}")]
        public IActionResult UpdatePublicSentiment(int id, [FromBody] PublicSentiment publicSentiment)
        {
            if (id != publicSentiment.SentimentID)
            {
                return BadRequest();
            }

            _dbContext.Entry(publicSentiment).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.PublicSentiments.Any(ps => ps.SentimentID == id))
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

        // DELETE: api/publicsentiment/5
        [HttpDelete("{id}")]
        public IActionResult DeletePublicSentiment(int id)
        {
            var publicSentiment = _dbContext.PublicSentiments.Find(id);
            if (publicSentiment == null)
            {
                return NotFound();
            }

            _dbContext.PublicSentiments.Remove(publicSentiment);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}