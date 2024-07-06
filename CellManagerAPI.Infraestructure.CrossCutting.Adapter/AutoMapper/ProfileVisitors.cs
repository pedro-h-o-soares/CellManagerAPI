using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Domain.Models;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.JsonPatch;

namespace CellManagerAPI.Infraestructure.CrossCutting.Adapter.AutoMapper;

public class ProfileVisitors : Profile
{
    public ProfileVisitors()
    {
        CreateMap<Visitor, ReadVisitorsDto>();
        CreateMap<CreateVisitorsDto, Visitor>();
        CreateMap<JsonPatchDocument<CreateVisitorsDto>, JsonPatchDocument<Visitor>>();
        CreateMap<Operation<CreateVisitorsDto>, Operation<Visitor>>();
    }
}
