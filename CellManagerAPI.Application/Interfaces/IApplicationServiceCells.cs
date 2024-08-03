using CellManagerAPI.Application.DTO.DTO;

namespace CellManagerAPI.Application.Interfaces;

public interface IApplicationServiceCells : IApplicationServiceBase<CreateCellsDto, ReadCellsDto>
{
}
