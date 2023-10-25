using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests;

public class TodoTest
{
    [Fact]
    public void TodoParameterDoneHasToBeFalseInCreation()
    {
        var todo = new TodoItem("Titulo Aqui", "Gabriel Chites", DateTime.Now);
        
        Assert.False(todo.Done);
    }
}
