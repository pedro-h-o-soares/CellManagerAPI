namespace CellManagerAPI.Domain.Models;

public class Cell : Base
{
    public int Number { get; set; }
    public int SupervisionId { get; set; }
    public virtual Supervision Supervision { get; set; }
    public virtual ICollection<Member> Members { get; set; }
    public virtual ICollection<Visitor> Visitors { get; set; }
}