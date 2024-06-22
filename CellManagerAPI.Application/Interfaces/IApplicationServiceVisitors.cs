using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Application.Interfaces;

public interface IApplicationServiceVisitors : IApplicationServiceBase<Visitor, CreateVisitorsDto, ReadVisitorsDto>
{
}
