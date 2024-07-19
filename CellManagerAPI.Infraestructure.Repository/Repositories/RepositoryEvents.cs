using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Models;
using CellManagerAPI.Infraestructure.Data;

namespace CellManagerAPI.Infraestructure.Repository.Repositories;

public class RepositoryEvents : 
    RepositoryBase<Event>,
    IRepositoryEvents
{
    public RepositoryEvents(CellManagerContext context) : base(context)
    {
    }
}
