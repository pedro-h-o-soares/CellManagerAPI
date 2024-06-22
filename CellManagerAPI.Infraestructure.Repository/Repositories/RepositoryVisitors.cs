using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Models;
using CellManagerAPI.Infraestructure.Data;

namespace CellManagerAPI.Infraestructure.Repository.Repositories;

public class RepositoryVisitors : 
    RepositoryBase<Visitor>,
    IRepositoryVisitors
{
    public RepositoryVisitors(CellManagerContext context) : base(context)
    {
    }
}
