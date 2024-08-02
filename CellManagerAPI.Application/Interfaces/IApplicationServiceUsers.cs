using CellManagerAPI.Application.DTO.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;

namespace CellManagerAPI.Application.Interfaces;

public interface IApplicationServiceUsers
{
    IEnumerable<ReadUsersDto> GetAll(int skip, int take);

    Task<ReadUsersDto> GetById(string id);

    Task Update(string id, UpdateUsersDto dto);

    Task Patch(string id, JsonPatchDocument<UpdateUsersDto> dto);

    Task Remove(string id);

    void Dispose();
}
