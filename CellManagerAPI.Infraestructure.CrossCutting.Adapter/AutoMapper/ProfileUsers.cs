using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.JsonPatch;

namespace CellManagerAPI.Infraestructure.CrossCutting.Adapter.AutoMapper;

public class ProfileUsers : Profile
{
    public ProfileUsers()
    {
        CreateMap<CreateUsersDto, IdentityUser>();
        CreateMap<UpdateUsersDto, IdentityUser>();
        CreateMap<IdentityUser, ReadUsersDto>();
    }
}
