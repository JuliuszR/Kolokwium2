using Kolokwium2.Exceptions;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NurseriesController : ControllerBase
{
    private readonly IDbService _dbService;

    public NurseriesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/batches")]
    public async Task<IActionResult> GetNurseriesByIdAsync(int id)
    {
        try
        {
            var nursery = await _dbService.GetNurseryByIdAsync(id);
            return Ok(nursery);
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
    }
}