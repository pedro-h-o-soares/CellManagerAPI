using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Domain.Services.Services;

public class ServiceEvents :
    ServiceBase<Event>,
    IServiceEvents
{
    public ServiceEvents(IRepositoryEvents repository) : base(repository)
    {
    }
}
