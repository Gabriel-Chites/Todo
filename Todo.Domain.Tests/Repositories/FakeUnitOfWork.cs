using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeUnitOfWork : IUnitOfWork
{
    public Task Commit()
    {
        return Task.CompletedTask;
    }

    public Task RollBack()
    {
        return Task.CompletedTask;
    }
}
