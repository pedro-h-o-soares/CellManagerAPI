using CellManagerAPI.Application.DTO.DTO;

namespace CellManagerAPI.Application.Interfaces;

public interface IApplicationServiceEvents : IApplicationServiceBase<CreateEventsDto, ReadEventsDto>
{
    void UpdateMembers(int id, IEnumerable<int> membersId);
    void UpdateVisitors(int id, IEnumerable<int> visitorsId);
}
