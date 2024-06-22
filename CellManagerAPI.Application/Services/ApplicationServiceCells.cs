using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Application.Services;

public class ApplicationServiceCells :
    ApplicationServiceBase<Cell, CreateCellsDto, ReadCellsDto>,
    IApplicationServiceCells
{
    public ApplicationServiceCells(IServiceCells service, IMapper mapper) : 
        base(service, mapper)
    {
    }
}
