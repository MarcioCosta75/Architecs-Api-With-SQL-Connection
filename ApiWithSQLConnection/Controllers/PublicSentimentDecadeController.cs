using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiWithSQLConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicSentimentDecadeController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public PublicSentimentDecadeController(DatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: api/publicsentimentdecade
        [HttpGet]
        public ActionResult<IEnumerable<PublicSentiment_Decade>> GetAllPublicSentimentsDecade()
        {
            return _dbContext.PublicSentiment_Decades.ToList();
        }

        // GET: api/publicsentimentdecade/5
        [HttpGet("{id}")]
        public ActionResult<PublicSentiment_Decade> GetPublicSentimentDecadeById(int id)
        {
            var publicSentimentDecade = _dbContext.PublicSentiment_Decades.Find(id);
            if (publicSentimentDecade == null)
            {
                return NotFound();
            }
            return publicSentimentDecade;
        }

        // POST: api/publicsentimentdecade
        [HttpPost]
        public ActionResult<PublicSentiment_Decade> PostPublicSentimentDecade([FromBody] PublicSentiment_Decade publicSentimentDecade)
        {
            _dbContext.PublicSentiment_Decades.Add(publicSentimentDecade);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetPublicSentimentDecadeById), new { id = publicSentimentDecade.SentimentID }, publicSentimentDecade);
        }

        // PUT: api/publicsentimentdecade/5
        [HttpPut("{id}")]
        public IActionResult UpdatePublicSentimentDecade(int id, [FromBody] PublicSentiment_Decade publicSentimentDecade)
        {
            if (id != publicSentimentDecade.SentimentID)
            {
                return BadRequest();
            }

            _dbContext.Entry(publicSentimentDecade).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.PublicSentiment_Decades.Any(psd => psd.SentimentID == id))
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

        // DELETE: api/publicsentimentdecade/5
        [HttpDelete("{id}")]
        public IActionResult DeletePublicSentimentDecade(int id)
        {
            var publicSentimentDecade = _dbContext.PublicSentiment_Decades.Find(id);
            if (publicSentimentDecade == null)
            {
                return NotFound();
            }

            _dbContext.PublicSentiment_Decades.Remove(publicSentimentDecade);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}