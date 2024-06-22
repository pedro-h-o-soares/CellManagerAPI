using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Models;
using CellManagerAPI.Infraestructure.Data;

namespace CellManagerAPI.Infraestructure.Repository.Repositories;

public class RepositorySupervisions : 
    RepositoryBase<Supervision>,
    IRepositorySupervisions
{
    public RepositorySupervisions(CellManagerContext context) : base(context)
    {
    }
}
