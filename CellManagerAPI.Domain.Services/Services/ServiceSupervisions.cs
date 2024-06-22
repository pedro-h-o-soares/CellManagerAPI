using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Domain.Services.Services;

public class ServiceSupervisions : ServiceBase<Supervision>, IServiceSupervisions
{
    public ServiceSupervisions(IRepositorySupervisions repository) : base(repository)
    {
    }
}
