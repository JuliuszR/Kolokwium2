using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Nursery> Nurseries { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    public DbSet<SeedingBatch> SeedingBatches { get; set; }
    public DbSet<TreeSpecies> TreeSpecies { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(new Employee
        {
            EmployeeId = 1,
            FirstName = "John",
            LastName = "Smith",
            HireDate = DateTime.Parse("2025-05-01")
        });

        modelBuilder.Entity<TreeSpecies>().HasData(new TreeSpecies
        {
            SpeciesId = 1,
            LatinName = "Lorem Ipsum",
            GrowthTimeInYears = 100
        });

        modelBuilder.Entity<Nursery>().HasData(new Nursery()
        {
            NurseryId = 1,
            Name = "Lesniczowka",
            EstablishedDate = DateTime.Parse("2025-05-01")
        });

        modelBuilder.Entity<SeedingBatch>().HasData(new SeedingBatch()
        {
            BatchId = 1,
            NurseryId = 1,
            SpeciesId = 1,
            Quantity = 50,
            SownDate = DateTime.Parse("2025-05-01"),
            ReadyDate = DateTime.Parse("2025-05-06")
        });

        modelBuilder.Entity<Responsible>().HasData(new Responsible()
        {
            BatchId = 1,
            EmployeeId = 1,
            Role = "Zbieranie"
        });
    }
}