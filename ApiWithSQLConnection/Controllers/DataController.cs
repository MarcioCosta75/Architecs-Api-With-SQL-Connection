using Microsoft.AspNetCore.Mvc;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private readonly DatabaseContext _dbContext;

    public DataController(DatabaseContext context)
    {
        _dbContext = context;
    }

    [HttpGet("GovernmentPolicies")]
    public async Task<ActionResult<IEnumerable<Government_Policy>>> GetGovernmentPolicies()
    {
        return await _dbContext.Government_Policies.ToListAsync();
    }

    [HttpGet("Decade")]
    public async Task<ActionResult<IEnumerable<Decade>>> GetDecade()
    {
        return await _dbContext.Decades.ToListAsync();
    }

    [HttpGet("Neighborhood")]
    public async Task<ActionResult<IEnumerable<Neighborhood>>> GetNeighborhood()
    {
        return await _dbContext.Neighborhoods.ToListAsync();
    }

    [HttpGet("Prices")]
    public async Task<ActionResult<IEnumerable<Price>>> GetPrice()
    {
        return await _dbContext.Prices.ToListAsync();
    }

    [HttpGet("Property")]
    public async Task<ActionResult<IEnumerable<Property>>> GetProperty()
    {
        return await _dbContext.Properties.ToListAsync();
    }

    [HttpGet("PublicSentiment")]
    public async Task<ActionResult<IEnumerable<PublicSentiment>>> GetPublicSentiment()
    {
        return await _dbContext.PublicSentiments.ToListAsync();
    }

    [HttpGet("Region")]
    public async Task<ActionResult<IEnumerable<Region>>> GetRegion()
    {
        return await _dbContext.Regions.ToListAsync();
    }

}