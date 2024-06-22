namespace CellManagerAPI.Application.DTO.DTO;

public class ReadCellsDto : ReadBaseDto
{
    public int Number { get; set; }
    public string SupervisionColor { get; set; }
    public ICollection<ReadMembersDto> Members { get; set; }
    public ICollection<ReadVisitorsDto> Visitors { get; set; }
}
