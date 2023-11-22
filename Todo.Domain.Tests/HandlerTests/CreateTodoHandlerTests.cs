using Moq;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

public class CreateTodoHandlerTests
{
    private readonly CreateTodoCommand _validCommand =
    new CreateTodoCommand("Title of Task", "Gabriel Alves", DateTime.UtcNow.AddDays(4));

    private readonly CreateTodoCommand _invalidCommand =
         new CreateTodoCommand("", "", DateTime.Now.AddMinutes(4));

    private readonly Mock<IUnitOfWork> _uow  = new Mock<IUnitOfWork>();
    private readonly Mock<ITodoRepository> _repository = new Mock<ITodoRepository>();

    private readonly TodoHandler _handler;

    private readonly CancellationToken _cancellationToken =
        new CancellationToken();

    private GenericCommandResult _result = 
        new GenericCommandResult();

    public CreateTodoHandlerTests()
    {
        _handler = new TodoHandler(_repository.Object, _uow.Object);
    }


    [Fact]
    public async Task ShouldInterruptFlowWhenHasAnInvalidCommandAsync()
    {
        _result = (GenericCommandResult)await _handler.Handle(_invalidCommand, _cancellationToken);

        Assert.False(_result.Success);

        _repository.Verify(x => x.Create(It.IsAny<TodoItem>()), Times.Never);
        _uow.Verify(x => x.Commit(), Times.Never);
    }

    [Fact]
    public async void ShouldCreateATaskWhenHasAnValidCommand()
    {
        _result = (GenericCommandResult)await _handler.Handle(_validCommand, _cancellationToken);

        _repository.Setup(x => x.Create(_validCommand)).Returns(Task.CompletedTask);

        Assert.True(_result.Success);
    }
}
