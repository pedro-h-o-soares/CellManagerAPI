using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Models;
using CellManagerAPI.Infraestructure.Data;

namespace CellManagerAPI.Infraestructure.Repository.Repositories;

public class RepositoryMembers : 
    RepositoryBase<Member>,
    IRepositoryMembers
{
    public RepositoryMembers(CellManagerContext context) : base(context)
    {
    }
}
