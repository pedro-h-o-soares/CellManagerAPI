using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Infraestructure.CrossCutting.Adapter.AutoMapper;

public class ProfileCells : Profile
{
    public ProfileCells()
    {
        CreateMap<Cell, ReadCellsDto>().ForMember(
            dto => dto.SupervisionColor,
            opt => opt.MapFrom(cell => cell.Supervision.Color));
        CreateMap<CreateCellsDto, Cell>();
    }
}
