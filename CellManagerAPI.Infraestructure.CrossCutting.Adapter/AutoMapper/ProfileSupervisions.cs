using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Domain.Models;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.JsonPatch;

namespace CellManagerAPI.Infraestructure.CrossCutting.Adapter.AutoMapper;

public class ProfileSupervisions : Profile
{
    public ProfileSupervisions()
    {
        CreateMap<Supervision, ReadSupervisionsDto>();
        CreateMap<CreateSupervisionsDto, Supervision>();
        CreateMap<JsonPatchDocument<CreateSupervisionsDto>, JsonPatchDocument<Supervision>>();
        CreateMap<Operation<CreateSupervisionsDto>, Operation<Supervision>>();
    }
}
