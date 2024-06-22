using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Application.Services;

public class ApplicationServiceMembers :
    ApplicationServiceBase<Member, CreateMembersDto, ReadMembersDto>,
    IApplicationServiceMembers
{
    public ApplicationServiceMembers(IServiceMembers service, IMapper mapper) : 
        base(service, mapper)
    {
    }
}
