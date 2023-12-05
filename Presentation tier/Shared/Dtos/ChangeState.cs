namespace Shared.Dtos;

public class ChangeState
{
    public Guid id { get; set; }
    public String state { get; set; }

    public ChangeState(Guid id, String state)
    {
        this.id = id;
        this.state = state;
    }
}