using Infrastructure.Persistence;

namespace Infrastructure.Repositories;
public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : class;
    Task<int> SaveAsync();
    Task<IReadOnlyList<T>> GetAllAsync<T>(int pageIndex, int pageSize) where T : class;
    Task<int> CountAsync<T>() where T : class;
    Task<IReadOnlyList<T>> GetAllAsync<T>(ISpecification<T> spec) where T : class;
    Task<int> CountAsync<T>(ISpecification<T> spec) where T : class;
}

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    private bool _disposed = false;

    public UnitOfWork(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IRepository<T> Repository<T>() where T : class
    {
        return new Repository<T>(_context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync<T>(int pageIndex, int pageSize) where T : class
    {
        return await Repository<T>().GetAllAsync(pageIndex, pageSize);
    }

    public async Task<int> CountAsync<T>() where T : class
    {
        return await Repository<T>().CountAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync<T>(ISpecification<T> spec) where T : class
    {
        return await Repository<T>().GetAllAsync(spec);
    }

    public async Task<int> CountAsync<T>(ISpecification<T> spec) where T : class
    {
        return await Repository<T>().CountAsync(spec);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}