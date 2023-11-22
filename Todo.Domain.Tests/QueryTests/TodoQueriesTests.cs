using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests;

public class TodoQueriesTests
{
    private List<TodoItem> _items;

    public TodoQueriesTests()
    {
        _items = new List<TodoItem>
        {
            new TodoItem("Tarefa 1", "usuarioA", DateTime.Now),
            new TodoItem("Tarefa 2", "usuarioA", DateTime.Now),
            new TodoItem("Tarefa 3", "usuarioB", DateTime.Now),
            new TodoItem("Tarefa 4", "usuarioA", DateTime.Now)
        };
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

    [Fact]
    public void ShouldReturnOnlyDoneTasks()
    {
        foreach (var item in _items)
            item.MarkAsDone();
        
        var result =
            _items
            .AsQueryable()
            .Where(TodoQueries.GetAllDone("usuarioA"));

        Assert.Equal(3, result.Count());
    }

    [Fact]
    public void ShouldReturnOnlyUndoneTasks()
    {
        var result =
            _items
            .AsQueryable()
            .Where(TodoQueries.GetAllUnDone("usuarioA"));

        Assert.Equal(3, result.Count());
    }
}
