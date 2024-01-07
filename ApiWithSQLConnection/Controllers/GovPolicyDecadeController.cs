using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiWithSQLConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GovPolicyDecadeController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public GovPolicyDecadeController(DatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: api/govpolicydecade
        [HttpGet]
        public ActionResult<IEnumerable<GovPolicy_Decade>> GetAllGovPoliciesDecade()
        {
            return _dbContext.GovPolicy_Decades.ToList();
        }

        // GET: api/govpolicydecade/5
        [HttpGet("{id}")]
        public ActionResult<GovPolicy_Decade> GetGovPolicyDecadeById(int id)
        {
            var govPolicyDecade = _dbContext.GovPolicy_Decades.Find(id);
            if (govPolicyDecade == null)
            {
                return NotFound();
            }
            return govPolicyDecade;
        }

        // POST: api/govpolicydecade
        [HttpPost]
        public ActionResult<GovPolicy_Decade> PostGovPolicyDecade([FromBody] GovPolicy_Decade govPolicyDecade)
        {
            _dbContext.GovPolicy_Decades.Add(govPolicyDecade);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetGovPolicyDecadeById), new { id = govPolicyDecade.PolicyID }, govPolicyDecade);
        }

        // PUT: api/govpolicydecade/5
        [HttpPut("{id}")]
        public IActionResult UpdateGovPolicyDecade(int id, [FromBody] GovPolicy_Decade govPolicyDecade)
        {
            if (id != govPolicyDecade.PolicyID)
            {
                return BadRequest();
            }

            _dbContext.Entry(govPolicyDecade).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.GovPolicy_Decades.Any(p => p.PolicyID == id))
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

        // DELETE: api/govpolicydecade/5
        [HttpDelete("{id}")]
        public IActionResult DeleteGovPolicyDecade(int id)
        {
            var govPolicyDecade = _dbContext.GovPolicy_Decades.Find(id);
            if (govPolicyDecade == null)
            {
                return NotFound();
            }

            _dbContext.GovPolicy_Decades.Remove(govPolicyDecade);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}