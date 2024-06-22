using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Domain.Services.Services;

public class ServiceMembers : ServiceBase<Member>, IServiceMembers
{
    public ServiceMembers(IRepositoryMembers repository) : base(repository)
    {
    }
}
