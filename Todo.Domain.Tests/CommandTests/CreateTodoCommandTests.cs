using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

public class CreateTodoCommandTests
{
    private readonly CreateTodoCommand _validCommand = 
        new CreateTodoCommand("Title of Task", "Gabriel Alves", DateTime.UtcNow.AddDays(4));

    private readonly CreateTodoCommand _invalidCommand =
         new CreateTodoCommand("", "", DateTime.Now);

    public CreateTodoCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [Fact]
    public void ShouldBeAnInvalidCommand()
    {
        Assert.False(_invalidCommand.Valid);
    }

    [Fact]
    public void ShouldBeAnValidCommand()
    {
        Assert.False(_validCommand.Invalid);
    }
}
