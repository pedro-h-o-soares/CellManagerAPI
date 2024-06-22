using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Models;
using CellManagerAPI.Infraestructure.Data;

namespace CellManagerAPI.Infraestructure.Repository.Repositories;

public class RepositoryCells : 
    RepositoryBase<Cell>,
    IRepositoryCells
{
    public RepositoryCells(CellManagerContext context) : base(context)
    {
    }
}
