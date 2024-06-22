using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Application.Interfaces;

public interface IApplicationServiceBase<TEntity, TCreateDto, TReadDto> : IDisposable
    where TEntity  : Base
    where TCreateDto : CreateBaseDto
    where TReadDto : ReadBaseDto
{
    IEnumerable<TReadDto> GetAll(int skip, int take);
    
    TReadDto GetById(int id);

    TEntity Add(TCreateDto dto);

    void Update(int id, TCreateDto dto);

    void Remove(int id);

    void Dispose();
}
