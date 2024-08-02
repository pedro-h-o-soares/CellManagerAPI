using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Application.Interfaces;

public interface IApplicationServiceEvents : IApplicationServiceBase<Event, CreateEventsDto, ReadEventsDto>
{
    void UpdateMembers(int id, IEnumerable<int> membersId);
    void UpdateVisitors(int id, IEnumerable<int> visitorsId);
}
