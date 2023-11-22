using Todo.Domain.Infra.Context;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    public async Task Commit()
    {
         await _context.SaveChangesAsync();
    }

    public Task RollBack()
    {
        throw new NotImplementedException();
    }
}
