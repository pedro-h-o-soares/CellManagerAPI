using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Domain.Services.Services;

public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : Base
{
    protected readonly IRepositoryBase<TEntity> _repository;

    public ServiceBase(IRepositoryBase<TEntity> repository)
    {
        _repository = repository;
    }

    public virtual IEnumerable<TEntity> GetAll(int skip, int take)
    {
        return _repository.GetAll().Skip(skip).Take(take);
    }

    public virtual TEntity? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public virtual TEntity Add(TEntity obj)
    {
        return _repository.Add(obj);
    }

    public virtual void Update(TEntity obj)
    {
        _repository.Update(obj);
    }

    public virtual void Remove(TEntity obj)
    {
        _repository.Remove(obj);
    }

    public virtual void Dispose()
    {
        _repository.Dispose();
    }
}
