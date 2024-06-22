using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Infraestructure.CrossCutting.Adapter.AutoMapper;

public class ProfileSupervisions : Profile
{
    public ProfileSupervisions()
    {
        CreateMap<Supervision, ReadSupervisionsDto>();
        CreateMap<CreateSupervisionsDto, Supervision>();
    }
}
