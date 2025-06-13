using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models;

public class SeedingBatch
{
    [Key]
    public int BatchId { get; set; }
    [ForeignKey(nameof(Nursery))]
    public int NurseryId { get; set; }
    [ForeignKey(nameof(Species))]
    public int SpeciesId { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime ReadyDate { get; set; }
    
    public ICollection<Responsible> Responsibles { get; set; }
    public Nursery Nursery { get; set; }
    public TreeSpecies Species { get; set; }
}