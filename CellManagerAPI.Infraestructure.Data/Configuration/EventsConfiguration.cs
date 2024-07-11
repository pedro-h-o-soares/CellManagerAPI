using CellManagerAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CellManagerAPI.Infraestructure.Data.Configuration;

public class EventsConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder
            .HasMany(e => e.Members)
            .WithMany();

        builder.HasMany(e => e.Visitors)
            .WithMany();
    }
}
