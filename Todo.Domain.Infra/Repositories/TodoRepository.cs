using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Context;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly DataContext _context;

    public TodoRepository(DataContext context)
    {
        _context = context;
    }

    public Task Create(TodoItem todo)
    { 
        _context.Todos.AddAsync(todo);
        return Task.CompletedTask;
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        return _context
               .Todos
               .AsNoTracking()
               .Where(TodoQueries.GetAll(user))
               .OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        return _context
               .Todos
               .AsNoTracking()
               .Where(TodoQueries.GetAllDone(user))
               .OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
        return _context
               .Todos
               .AsNoTracking()
               .Where(TodoQueries.GetAllUnDone(user))
               .OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
    {
        return _context
               .Todos
               .Where(TodoQueries.GetByPeriod(user, date, done))
               .OrderBy(x => x.Date);
    }

    public Task<TodoItem?> GetTodoById(Guid id, string user)
    {
        return _context
               .Todos
               .FirstOrDefaultAsync(TodoQueries.GetById(id, user));
    }

    public Task Update(TodoItem todo)
    {
         _context.Todos.Update(todo);
         return Task.CompletedTask;
    }
}
