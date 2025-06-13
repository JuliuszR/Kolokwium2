using Kolokwium2.Models.Dtos;

namespace Kolokwium2.Services;

public interface IDbService
{
    Task<NurseryRequestDto> GetNurseryByIdAsync(int id);
    Task AddBatchAsync(NewBatchDto dto);
}