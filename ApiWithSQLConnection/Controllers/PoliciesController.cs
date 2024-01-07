using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiWithSQLConnection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoliciesController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public PoliciesController(DatabaseContext context)
        {
            _dbContext = context;
        }

        #region Government Policies

        // GET: api/policies
        [HttpGet]
        public ActionResult<IEnumerable<Government_Policy>> GetPolicies()
        {
            return _dbContext.Government_Policies.ToList();
        }

        // GET: api/policies/5
        [HttpGet("{id}")]
        public ActionResult<Government_Policy> GetPolicyById(int id)
        {
            var policy = _dbContext.Government_Policies.FirstOrDefault(p => p.PolicyID == id);

            if (policy == null)
            {
                return NotFound();
            }

            return policy;
        }

        // POST: api/policies
        [HttpPost]
        public ActionResult<Government_Policy> InsertPolicy([FromBody] Government_Policy policy)
        {
            _dbContext.Government_Policies.Add(policy);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetPolicyById), new { id = policy.PolicyID }, policy);
        }

        // PUT: api/policies/5
        [HttpPut("{id}")]
        public IActionResult UpdatePolicy(int id, [FromBody] Government_Policy policy)
        {
            if (id != policy.PolicyID)
            {
                return BadRequest();
            }

            _dbContext.Entry(policy).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Government_Policies.Any(p => p.PolicyID == id))
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

        // DELETE: api/policies/5
        [HttpDelete("{id}")]
        public IActionResult DeletePolicy(int id)
        {
            var policy = _dbContext.Government_Policies.Find(id);
            if (policy == null)
            {
                return NotFound();
            }

            _dbContext.Government_Policies.Remove(policy);
            _dbContext.SaveChanges();

            return NoContent();
        }

        #endregion

        // Aqui você pode adicionar mais métodos para manipular outras entidades conforme necessário.
    }
}