using Kolokwium2.Data;
using Kolokwium2.Exceptions;
using Kolokwium2.Models.Dtos;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BatchesController : ControllerBase
{
    private readonly IDbService _dbService;

    public BatchesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewBatch(NewBatchDto dto)
    {
        try
        {
            await _dbService.AddBatchAsync(dto);
            return Created();
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}