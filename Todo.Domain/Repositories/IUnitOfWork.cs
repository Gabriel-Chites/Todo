namespace Todo.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
    Task RollBack();
}
