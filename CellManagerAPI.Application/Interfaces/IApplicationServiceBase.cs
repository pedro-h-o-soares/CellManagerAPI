using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace CellManagerAPI.Application.Interfaces;

public interface IApplicationServiceBase<TCreateDto, TReadDto> : IDisposable
    where TCreateDto : CreateBaseDto
    where TReadDto : ReadBaseDto
{
    IEnumerable<TReadDto> GetAll(int skip, int take);
    
    TReadDto GetById(int id);

    TReadDto Add(TCreateDto dto);

    void Update(int id, TCreateDto dto);

    void Patch(int id, JsonPatchDocument<TCreateDto> dto);

    void Remove(int id);

    void Dispose();
}
