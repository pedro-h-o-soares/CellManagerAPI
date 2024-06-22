using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Infraestructure.CrossCutting.Adapter.AutoMapper;

public class ProfileMembers : Profile
{
    public ProfileMembers()
    {
        CreateMap<Member, ReadMembersDto>();
        CreateMap<CreateMembersDto, Member>();
    }
}
