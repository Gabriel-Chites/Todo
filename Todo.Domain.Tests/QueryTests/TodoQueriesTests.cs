using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests;

public class TodoQueriesTests
{
    private List<TodoItem> _items;

    public TodoQueriesTests()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 3", "usuarioB", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now));
    }

    [Fact]
    public void ShouldReturnOnlyUserTasks()
    {
        var result = 
            _items
            .AsQueryable()
            .Where(TodoQueries.GetAll("usuarioA"));

        Assert.Equal(3, result.Count());
    }
}
