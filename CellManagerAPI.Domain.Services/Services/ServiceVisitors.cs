using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Domain.Services.Services;

public class ServiceVisitors : ServiceBase<Visitor>, IServiceVisitors
{
    public ServiceVisitors(IRepositoryVisitors repository) : base(repository)
    {
    }
}
