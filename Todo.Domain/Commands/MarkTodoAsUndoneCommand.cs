namespace Todo.Domain.Commands;

public class MarkTodoAsUndoneCommand : MarkTodoCommand
{
    public MarkTodoAsUndoneCommand() : base() { }

    public MarkTodoAsUndoneCommand(Guid id, string user) 
        : base(id, user) { }
}
