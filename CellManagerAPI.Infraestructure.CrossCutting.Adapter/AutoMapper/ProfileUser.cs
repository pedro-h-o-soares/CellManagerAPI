using AutoMapper;
using CellManagerAPI.Application.DTO.DTO.Auth;
using Microsoft.AspNetCore.Identity;

namespace CellManagerAPI.Infraestructure.CrossCutting.Adapter.AutoMapper;

public class ProfileUser : Profile
{
    public ProfileUser()
    {
        CreateMap<CreateUserDto, IdentityUser>();
    }
}
