namespace Todo.Domain.Commands;

public class MarkTodoAsDoneCommand : MarkTodoCommand
{
    public MarkTodoAsDoneCommand() : base() { } 
    
    public MarkTodoAsDoneCommand(Guid id, string user) 
        : base(id, user) { }
}
