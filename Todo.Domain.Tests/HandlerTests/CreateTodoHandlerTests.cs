using System.Threading;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

public class CreateTodoHandlerTests
{
    private readonly CreateTodoCommand _validCommand =
    new CreateTodoCommand("Title of Task", "Gabriel Alves", DateTime.UtcNow.AddDays(4));

    private readonly CreateTodoCommand _invalidCommand =
         new CreateTodoCommand("", "", DateTime.Now);

    private readonly TodoHandler _handler =
            new TodoHandler(new FakeRepository(), new FakeUnitOfWork());

    private readonly CancellationToken _cancellationToken =
        new CancellationToken();

    private GenericCommandResult _result = 
        new GenericCommandResult();


    [Fact]
    public async Task ShouldInterruptFlowWhenHasAnInvalidCommandAsync()
    {
        _result = (GenericCommandResult)await _handler.Handle(_invalidCommand, _cancellationToken);

        Assert.False(_result.Success);
    }

    [Fact]
    public async void ShouldCreateATaskWhenHasAnValidCommand()
    {
        _result = (GenericCommandResult)await _handler.Handle(_invalidCommand, _cancellationToken);

        Assert.True(_result.Success);
    }
}
