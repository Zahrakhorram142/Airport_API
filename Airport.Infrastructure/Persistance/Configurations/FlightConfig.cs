using Airport.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Airport.Infrastructure.Persistance.Configurations;

public class FlightConfig : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder
            .HasKey(x => x.Id)
            .IsClustered()
            .HasName("PK_BASE_Flight");

        builder
             .Property(x => x.Origin)
             .IsRequired()
             .HasMaxLength(250);
    }
}
