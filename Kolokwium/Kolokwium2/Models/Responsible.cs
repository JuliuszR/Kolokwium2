using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models;

[PrimaryKey(nameof(BatchId), nameof(EmployeeId))]
public class Responsible
{
    [ForeignKey(nameof(Batch))]
    public int BatchId { get; set; }
    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }
    [MaxLength(100)]
    public string Role { get; set; }
    
    public SeedingBatch Batch { get; set; }
    public Employee Employee { get; set; }
}