namespace Kolokwium2.Models.Dtos;

public class NurseryRequestDto
{
    public int NurseryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }
    public List<BatchesRequestDto> Batches { get; set; }
}

public class BatchesRequestDto
{
    public int BatchId { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime ReadyDate { get; set; }
    public SpeciesRequestDto Species { get; set; }
    public List<ResponsibleRequestDto> Responsible { get; set; }
}

public class ResponsibleRequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
}

public class SpeciesRequestDto
{
    public string LatinName { get; set; }
    public int GrowthTimeInYears { get; set; }
}