using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.Models;

public class TreeSpecies
{
    [Key]
    public int SpeciesId { get; set; }
    [MaxLength(100)]
    public string LatinName { get; set; }
    public int GrowthTimeInYears { get; set; }
    
    public ICollection<SeedingBatch> seedingBatches { get; set; }
}