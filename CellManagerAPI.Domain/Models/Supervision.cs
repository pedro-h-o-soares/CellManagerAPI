namespace CellManagerAPI.Domain.Models;

public class Supervision : Base
{
    public string Color { get; set; }
    public virtual ICollection<Cell> Cells { get; set; }
}