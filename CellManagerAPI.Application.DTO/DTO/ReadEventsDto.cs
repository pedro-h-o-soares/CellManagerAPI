namespace CellManagerAPI.Application.DTO.DTO;

public class ReadEventsDto : ReadBaseDto
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public int? CellId { get; set; }
    public virtual ICollection<ReadMembersDto> Members { get; set; }
    public virtual ICollection<ReadVisitorsDto> Visitors { get; set; }
}
