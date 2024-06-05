using Airport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Airport.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

        
    }

    public DbSet<Airplane> Airplanes { get; set; }
    public DbSet<Flight> Flights { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema("BASE");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
    public override int SaveChanges()
    {
        Console.WriteLine("Hello from zahra before save changes");
        return base.SaveChanges();
    }
}
