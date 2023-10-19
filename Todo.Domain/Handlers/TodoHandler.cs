using Flunt.Notifications;
using MediatR;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler : 
    Notifiable,
    IRequestHandler<CreateTodoCommand, ICommandResult>
   
{
    private readonly ITodoRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public TodoHandler(ITodoRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ICommandResult> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        request.Validate();

        if (request.Invalid)
             return new GenericCommandResult(
                success: false,
                message: "Ops, parece que sua tarefa está errada!",
                data: request.Notifications);

        var todo = (TodoItem)request;

        await _repository.Create(todo);

        await _unitOfWork.Commit();

        return new GenericCommandResult(
                success: true,
                message: "Sucesso",
                data: todo);
    }
}