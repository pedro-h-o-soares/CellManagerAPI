using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace CellManagerAPI.Infraestructure.CrossCutting.Adapter.AutoMapper;

public class ProfileMembers : Profile
{
    public ProfileMembers()
    {
        CreateMap<Member, ReadMembersDto>();
        CreateMap<CreateMembersDto, Member>();
        CreateMap<JsonPatchDocument<CreateMembersDto>, JsonPatchDocument<Member>>();
        CreateMap<Operation<CreateMembersDto>, Operation<Member>>();
    }
}
