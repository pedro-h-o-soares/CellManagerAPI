using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.JsonPatch;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Infraestructure.CrossCutting.Adapter.AutoMapper;

public class ProfileEvents : Profile
{
    public ProfileEvents()
    {
        CreateMap<Event, ReadEventsDto>();
        CreateMap<CreateEventsDto, Event>();
        CreateMap<JsonPatchDocument<CreateEventsDto>, JsonPatchDocument<Event>>();
        CreateMap<Operation<CreateEventsDto>, Operation<Event>>();
    }
}
