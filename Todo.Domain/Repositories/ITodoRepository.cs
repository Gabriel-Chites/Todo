using Todo.Domain.Entities;

namespace Todo.Domain.Repositories;

public interface ITodoRepository
{
    Task Create(TodoItem todo);

    Task Update(TodoItem todo);

    Task<TodoItem> GetTodoById(Guid id, string user);
}
