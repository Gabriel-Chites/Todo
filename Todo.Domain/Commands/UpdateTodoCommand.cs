using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Todo.Domain.Commands;

public class UpdateTodoCommand : Notifiable, ICommand
{
    public UpdateTodoCommand() { }
    public UpdateTodoCommand(Guid id, string title, string user)
    {
        Id = id;
        Title = title;
        User = user;
    }

    public Guid Id { get; set; }

    public string Title { get; set; }

    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
            .Requires()
            .HasMinLen(Title, 3, "Title",
                "Por favor, descreva melhor a sua tarefa!")
            .HasMinLen(User, 6, "User",
                "Usuário Inválido!"));
    }
}
