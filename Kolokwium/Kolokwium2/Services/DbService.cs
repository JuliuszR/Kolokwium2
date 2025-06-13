using Kolokwium2.Data;
using Kolokwium2.Exceptions;
using Kolokwium2.Models;
using Kolokwium2.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<NurseryRequestDto> GetNurseryByIdAsync(int nurseryId)
    {
        var nursery = await _context.Nurseries
            .Select(n => new NurseryRequestDto
            {
                NurseryId = n.NurseryId,
                Name = n.Name,
                EstablishedDate = n.EstablishedDate,
                Batches = n.SeedingBatches.Select(s => new BatchesRequestDto()
                {
                    BatchId = s.BatchId,
                    Quantity = s.Quantity,
                    SownDate = s.SownDate,
                    ReadyDate = s.ReadyDate,
                    Species = new SpeciesRequestDto()
                    {
                        LatinName = s.Species.LatinName,
                        GrowthTimeInYears = s.Species.GrowthTimeInYears
                    },
                    Responsible = s.Responsibles.Select(r => new ResponsibleRequestDto()
                    {
                        FirstName = r.Employee.FirstName,
                        LastName = r.Employee.LastName,
                        Role = r.Role
                    }).ToList()
                }).ToList()
            }).FirstOrDefaultAsync(e => e.NurseryId == nurseryId);

        if (nursery == null)
        {
            throw new NotFoundException();
        }
        return nursery;
    }

    public async Task AddBatchAsync(NewBatchDto dto)
    {
        var species =await _context.TreeSpecies.FirstOrDefaultAsync(s => s.LatinName == dto.Species);
        if (species == null)
        {
            throw new NotFoundException("Nie istnieje gatunek o podanej nazwie");
        }
        
        var nursery = await _context.Nurseries.FirstOrDefaultAsync(n => n.Name == dto.Nursery);
        if (nursery == null)
        {
            throw new NotFoundException("Nie istnieje szkółka leśna o podanej nazwie");
        }
        
        var employee = dto.Responsible.Select(r => r.EmployeeId).ToList();
        var existingEmployees = await _context.Employees
            .Where(e => employee.Contains(e.EmployeeId))
            .Select(e => e.EmployeeId)
            .ToListAsync();
        
        var missing = employee.Except(existingEmployees).ToList();
        if (missing.Any())
        {
            throw new NotFoundException("Nie istnieje pracownik o podanym id");
        }

        var batch = new SeedingBatch()
        {
            Quantity = dto.Quantity,
            SownDate = DateTime.Parse("2020-08-01"),
            ReadyDate = DateTime.Parse("2020-08-10"),
            SpeciesId = species.SpeciesId,
            NurseryId = nursery.NurseryId,
            Responsibles = dto.Responsible.Select(r => new Responsible()
            {
                EmployeeId = r.EmployeeId,
                Role = r.Role
            }).ToList()
        };
        
        _context.SeedingBatches.Add(batch);
        await _context.SaveChangesAsync();
    }
    
    
}