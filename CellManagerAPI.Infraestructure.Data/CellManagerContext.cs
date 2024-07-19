using CellManagerAPI.Domain.Models;
using CellManagerAPI.Infraestructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CellManagerAPI.Infraestructure.Data;

public class CellManagerContext : DbContext
{
    public DbSet<Cell> Cells { get; set; }
    public DbSet<Supervision> Supervisions { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Visitor> Visitors { get; set; }
    public DbSet<Event> Events { get; set; }

    public CellManagerContext(DbContextOptions<CellManagerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CellsConfiguration());
        builder.ApplyConfiguration(new EventsConfiguration());
    }
}
