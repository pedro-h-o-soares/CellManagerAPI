using AutoMapper;
using CellManagerAPI.Application.DTO.DTO;
using CellManagerAPI.Application.Interfaces;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Models;

namespace CellManagerAPI.Application.Services;

public class ApplicationServiceEvents :
    ApplicationServiceBase<Event, CreateEventsDto, ReadEventsDto>,
    IApplicationServiceEvents
{
    private readonly IServiceEvents _service;
    private readonly IMapper _mapper;
    private readonly IServiceMembers _serviceMembers;
    private readonly IServiceVisitors _serviceVisitors;

    public ApplicationServiceEvents(
        IServiceEvents service, 
        IMapper mapper, 
        IServiceMembers serviceMembers,
        IServiceVisitors serviceVisitors) : base(service, mapper)
    {
        _service = service;
        _mapper = mapper;
        _serviceMembers = serviceMembers;
        _serviceVisitors = serviceVisitors;
    }

    public void UpdateMembers(int id, IEnumerable<int> membersId)
    {
        var obj = _service.GetById(id) ?? throw new KeyNotFoundException($"No event with id [{id}] found");
        obj.Members.Clear();

        foreach (var memberId in membersId)
        {
            var member = _serviceMembers.GetById(memberId) ?? throw new KeyNotFoundException($"No member with id [{memberId}] found");
            if (!CanAdd(obj, member)) throw new Exception($"Cannot add member from different cell");

            obj.Members.Add(member);
        }

        _service.Update(obj);
    }

    public void UpdateVisitors(int id, IEnumerable<int> visitorsId)
    {
        var obj = _service.GetById(id) ?? throw new KeyNotFoundException($"No event with id [{id}] found");
        obj.Visitors.Clear();

        foreach (var visitorId in visitorsId)
        {
            var visitor = _serviceVisitors.GetById(visitorId) ?? throw new KeyNotFoundException($"No visitor with id [{visitorId}] found");
            if (!CanAdd(obj, visitor)) throw new Exception($"Cannot add visitor from different cell");
            
            obj.Visitors.Add(visitor);
        }

        _service.Update(obj);
    }

    private static bool CanAdd(Event @event, Frequenter frequenter)
    {
        if (@event is null) return false;
        if (frequenter is null) return false;
        if (@event.CellId != frequenter.CellId) return false;

        return true;
    }
}
