using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Domain.Core.Interfaces.Services;

public interface IServiceBase<TEntity> where TEntity : Base
{
    public IEnumerable<TEntity> GetAll(int skip, int take);
 
    public TEntity? GetById(int id);

    public TEntity Add(TEntity obj);

    public void Update(TEntity obj);

    public void Remove(TEntity obj);

    public void Dispose();
}
