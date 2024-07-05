using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Application.Services;

public class ApplicationServiceBase<TEntity, TCreateDto, TReadDto> : IApplicationServiceBase<TEntity, TCreateDto, TReadDto>
    where TEntity : Base
    where TCreateDto : CreateBaseDto
    where TReadDto : ReadBaseDto
{
    private readonly IServiceBase<TEntity> _service;
    private readonly IMapper _mapper;

    public ApplicationServiceBase(IServiceBase<TEntity> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public virtual IEnumerable<TReadDto> GetAll(int skip, int take)
    {
        var objs = _service.GetAll(skip, take).ToList();
        return _mapper.Map<List<TReadDto>>(objs);
    }

    public virtual TReadDto GetById(int id)
    {
        var obj = _service.GetById(id);
        return _mapper.Map<TReadDto>(obj);
    }

    public virtual TEntity Add(TCreateDto dto)
    {
        var obj = _mapper.Map<TEntity>(dto);
        var result = _service.Add(obj);

        return result;
    }

    public virtual void Update(int id, TCreateDto dto)
    {
        var obj = _service.GetById(id) ?? throw new Exception($"No element with id [{id}] found");

        _mapper.Map(dto, obj);
        _service.Update(obj);
    }

    public virtual void Remove(int id)
    {
        var obj = _service.GetById(id) ?? throw new Exception($"No element with id [{id}] found"); ;
        _service.Remove(obj);
    }

    public virtual void Dispose()
    {
        _service.Dispose();
    }
}
