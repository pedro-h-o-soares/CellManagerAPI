using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Application.Interfaces;

public interface IApplicationServiceSupervisions : IApplicationServiceBase<Supervision, CreateSupervisionsDto, ReadSupervisionsDto>
{
}
