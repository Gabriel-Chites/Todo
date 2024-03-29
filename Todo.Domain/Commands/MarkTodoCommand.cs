﻿using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public abstract class MarkTodoCommand : Notifiable, ICommand, IRequest<ICommandResult>
{
    public MarkTodoCommand() { }

    public MarkTodoCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }

    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract()
            .Requires()
            .HasMinLen(User, 6, "User",
                "Usuário inválido"));
    }
}
