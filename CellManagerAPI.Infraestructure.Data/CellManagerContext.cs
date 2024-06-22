using Microsoft.EntityFrameworkCore;

namespace CellManagerAPI.Infraestructure.Data;

public class CellManagerContext : DbContext
{
    public CellManagerContext(DbContextOptions<CellManagerContext> options) : base(options)
    {
    }
}
