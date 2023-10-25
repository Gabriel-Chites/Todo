using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeRepository : ITodoRepository
{
    public Task Create(TodoItem todo)
    {
        return Task.CompletedTask;
    }

    public Task<TodoItem> GetTodoById(Guid id, string user)
    {
        return Task.FromResult(new TodoItem());
    }

    public Task Update(TodoItem todo)
    {
        return Task.CompletedTask;
    }
}
