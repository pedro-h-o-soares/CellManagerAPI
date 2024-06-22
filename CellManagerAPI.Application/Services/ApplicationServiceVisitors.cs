using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Application.Services;

public class ApplicationServiceVisitors :
    ApplicationServiceBase<Visitor, CreateVisitorsDto, ReadVisitorsDto>,
    IApplicationServiceVisitors
{
    public ApplicationServiceVisitors(IServiceVisitors service, IMapper mapper) : 
        base(service, mapper)
    {
    }
}
