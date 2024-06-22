using CellManagerAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CellManagerAPI.Infraestructure.Data.Configuration;

public class CellsConfiguration : IEntityTypeConfiguration<Cell>
{
    public void Configure(EntityTypeBuilder<Cell> builder)
    {
        builder
            .HasOne(c => c.Supervision)
            .WithMany(s => s.Cells)
            .HasForeignKey(c => c.SupervisionId);

        builder
            .HasMany(c => c.Members)
            .WithOne(m => m.Cell)
            .HasForeignKey(m => m.CellId);

        builder
            .HasMany(c => c.Visitors)
            .WithOne(v => v.Cell)
            .HasForeignKey(v => v.CellId);
    }
}
