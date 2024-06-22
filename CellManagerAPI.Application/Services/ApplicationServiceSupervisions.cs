using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Application.Services;

public class ApplicationServiceSupervisions :
    ApplicationServiceBase<Supervision, CreateSupervisionsDto, ReadSupervisionsDto>,
    IApplicationServiceSupervisions
{
    public ApplicationServiceSupervisions(IServiceSupervisions service, IMapper mapper) : 
        base(service, mapper)
    {
    }
}
