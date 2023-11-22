using Todo.Domain.Entities;

namespace Todo.Domain.Repositories;

public interface ITodoRepository
{
    Task Create(TodoItem todo);

    Task Update(TodoItem todo);

    Task<TodoItem?> GetTodoById(Guid id, string user);

    IEnumerable<TodoItem> GetAll(string user);

    IEnumerable<TodoItem> GetAllDone(string user);

    IEnumerable<TodoItem> GetAllUndone(string user);

    IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done);
}
