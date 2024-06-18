using Airport.Domain.Contracts;
using Airport.Domain.Entities;
using Airport.Infrastructure.Extensions;
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
        builder.RegisterAllSeeders(typeof(IBaseSeeder<>).Assembly);
        builder.RegisterAllEntities(typeof(EntityAttribute).Assembly);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //   => modelBuilder
    //       .HasDefaultSchema(EntitySchema.Ens)
    //       .RegisterAllEntities(typeof(EntityAttribute).Assembly)
    //       .RegisterAllSeeders(typeof(IBaseSeeder<>).Assembly)
    //       .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    public override int SaveChanges()
    {
        Console.WriteLine("Hello from zahra before save changes");
        return base.SaveChanges();
    }
}
