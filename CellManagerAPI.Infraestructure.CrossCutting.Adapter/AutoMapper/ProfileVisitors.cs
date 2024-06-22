using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Infraestructure.CrossCutting.Adapter.AutoMapper;

public class ProfileVisitors : Profile
{
    public ProfileVisitors()
    {
        CreateMap<Visitor, ReadVisitorsDto>();
        CreateMap<CreateVisitorsDto, Visitor>();
    }
}
