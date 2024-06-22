using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Domain.Core.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : Base
{
    TEntity Add(TEntity obj);

    TEntity? GetById(int id);

    IQueryable<TEntity> GetAll();

    void Update(TEntity obj);

    void Remove(TEntity obj);

    void Dispose();
}
