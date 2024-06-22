using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Models;
using CellManagerAPI.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CellManagerAPI.Infraestructure.Repository.Repositories;

public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : Base
{
    private readonly CellManagerContext _context;

    public RepositoryBase(CellManagerContext context)
    {
        _context = context;
    }

    public virtual TEntity Add(TEntity obj)
    {
        try
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();

            return obj;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public virtual IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

    public virtual TEntity? GetById(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public virtual void Update(TEntity obj)
    {
        try
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public virtual void Remove(TEntity obj)
    {
        try
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public virtual void Dispose()
    {
        _context.Dispose();
    }
}
