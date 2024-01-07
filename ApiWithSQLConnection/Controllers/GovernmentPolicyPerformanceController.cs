using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiWithSQLConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GovernmentPolicyPerformanceController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public GovernmentPolicyPerformanceController(DatabaseContext context)
        {
            _dbContext = context;
        }

        // GET: api/governmentpolicyperformance
        [HttpGet]
        public ActionResult<IEnumerable<GovernmentPolicy_Performance>> GetAllPolicyPerformances()
        {
            return _dbContext.GovernmentPolicy_Performances.ToList();
        }

        // GET: api/governmentpolicyperformance/5
        [HttpGet("{id}")]
        public ActionResult<GovernmentPolicy_Performance> GetPolicyPerformanceById(int id)
        {
            var policyPerformance = _dbContext.GovernmentPolicy_Performances.Find(id);
            if (policyPerformance == null)
            {
                return NotFound();
            }
            return policyPerformance;
        }

        // POST: api/governmentpolicyperformance
        [HttpPost]
        public ActionResult<GovernmentPolicy_Performance> PostPolicyPerformance([FromBody] GovernmentPolicy_Performance policyPerformance)
        {
            _dbContext.GovernmentPolicy_Performances.Add(policyPerformance);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetPolicyPerformanceById), new { id = policyPerformance.PolicyID }, policyPerformance);
        }

        // PUT: api/governmentpolicyperformance/5
        [HttpPut("{id}")]
        public IActionResult UpdatePolicyPerformance(int id, [FromBody] GovernmentPolicy_Performance policyPerformance)
        {
            if (id != policyPerformance.PolicyID)
            {
                return BadRequest();
            }

            _dbContext.Entry(policyPerformance).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.GovernmentPolicy_Performances.Any(p => p.PolicyID == id))
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

        // DELETE: api/governmentpolicyperformance/5
        [HttpDelete("{id}")]
        public IActionResult DeletePolicyPerformance(int id)
        {
            var policyPerformance = _dbContext.GovernmentPolicy_Performances.Find(id);
            if (policyPerformance == null)
            {
                return NotFound();
            }

            _dbContext.GovernmentPolicy_Performances.Remove(policyPerformance);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}