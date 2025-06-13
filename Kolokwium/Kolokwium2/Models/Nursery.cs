using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.Models;

public class Nursery
{
    [Key]
    public int NurseryId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }
    
    public ICollection<SeedingBatch> SeedingBatches { get; set; }
}