﻿using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class CreateTodoCommand  : Notifiable, ICommand
{
    public CreateTodoCommand()
    {
        
    }

    public CreateTodoCommand(string title, string user, DateTime date)
    {
        Title = title;
        User = user;
        Date = date;
    }

    public string Title { get; set; }

    public string User { get; set; }
    //testing gitd
    public DateTime Date { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
            .Requires()
            .HasMinLen(Title, 3, "Title", 
                "Por favor, descreva melhor a sua tarefa!")
            .HasMinLen(User, 6, "User", 
                "Usuário Inválido!")
            .IsLowerThan(DateTime.UtcNow, Date, "Date", 
                "Não é possível criar tarefas no passado!"));
    }
}
