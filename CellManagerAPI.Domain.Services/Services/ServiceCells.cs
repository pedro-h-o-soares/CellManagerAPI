using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Domain.Services.Services;

public class ServiceCells : ServiceBase<Cell>, IServiceCells
{
    public ServiceCells(IRepositoryCells repository) : base(repository)
    {
    }
}
