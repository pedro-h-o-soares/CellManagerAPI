namespace CellManagerAPI.Application.DTO.DTO;

public class CreateCellsDto : CreateBaseDto
{
    public int Number { get; set; }
    public int SupervisionId { get; set; }
}
