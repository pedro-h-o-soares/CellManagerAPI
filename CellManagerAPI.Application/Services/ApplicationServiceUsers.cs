using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;

namespace CellManagerAPI.Application.Services;

public class ApplicationServiceUsers : IApplicationServiceUsers
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;

    public ApplicationServiceUsers(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public IEnumerable<ReadUsersDto> GetAll(int skip, int take)
    {
        var users = _userManager.Users.Skip(skip).Take(take).ToList();
        return _mapper.Map<List<ReadUsersDto>>(users);
    }

    public async Task<ReadUsersDto> GetById(string id)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
        var dto = _mapper.Map<ReadUsersDto>(user);

        dto.Roles = await _userManager.GetRolesAsync(user);

        return dto;
    }

    public async Task Update(string id, UpdateUsersDto dto)
    {
        var obj = _userManager.Users.FirstOrDefault(u => u.Id == id) ?? throw new KeyNotFoundException($"No element with id [{id}] found");

        _mapper.Map(dto, obj);

        await _userManager.UpdateAsync(obj);
    }

    public async Task Patch(string id, JsonPatchDocument<UpdateUsersDto> patch)
    {
        var obj = _userManager.Users.FirstOrDefault(u => u.Id == id) ?? throw new KeyNotFoundException($"No element with id [{id}] found");
        var entityPatch = _mapper.Map<JsonPatchDocument<IdentityUser>>(patch);

        entityPatch.ApplyTo(obj);
        await _userManager.UpdateAsync(obj);
    }

    public async Task Remove(string id)
    {
        var obj = _userManager.Users.FirstOrDefault(u => u.Id == id) ?? throw new KeyNotFoundException($"No element with id [{id}] found"); ;
        await _userManager.DeleteAsync(obj);
    }

    public void Dispose()
    {
        _userManager.Dispose();
    }
}
