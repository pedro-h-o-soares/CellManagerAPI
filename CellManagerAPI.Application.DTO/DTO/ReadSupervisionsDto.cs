namespace CellManagerAPI.Application.DTO.DTO;

public class ReadSupervisionsDto : ReadBaseDto
{
    public string Color { get; set; }
    public ICollection<ReadCellsDto> Cells { get; set; }
}