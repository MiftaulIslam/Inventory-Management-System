using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public interface IRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<bool> AddAsync(T entity);
    Task<bool> UpdateAsync(int id, T entity);
    Task<bool> DeleteAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync(int pageIndex, int pageSize);
    Task<int> CountAsync();
    Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T> spec);
    Task<int> CountAsync(ISpecification<T> spec);
}

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DataContext _context;

    public Repository(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id) ?? throw new ArgumentException($"Entity with ID {id} not found");
    }

    public async Task<bool> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(int id, T entity)
    {
        var existingEntity = await _context.Set<T>().FindAsync(id);
        if (existingEntity == null)
            return false;

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null)
            return false;

        _context.Set<T>().Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(int pageIndex, int pageSize)
    {
        // Check if T has an Id property (assuming it's an entity type)
        if (typeof(T).GetProperty("Id") == null)
        {
            throw new InvalidOperationException($"Type {typeof(T).Name} does not contain an 'Id' property.");
        }

        // Add an OrderBy clause to ensure consistent results
        return await _context.Set<T>()
            .OrderBy(e => EF.Property<int>(e, "Id")) // Replace 'Id' with the correct property name
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Set<T>().CountAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T> spec)
    {
        var query = ApplySpecification(spec);
        return await query.ToListAsync();
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        var query = ApplySpecification(spec);
        return await query.CountAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        var query = _context.Set<T>().AsQueryable();

        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }

        foreach (var include in spec.Includes)
        {
            query = query.Include(include);
        }

        if (spec.Ascending != null)
        {
            query = query.OrderBy(spec.Ascending);
        }

        if (spec.Descending != null)
        {
            query = query.OrderByDescending(spec.Descending);
        }

        if (spec.IsPagingEnabled)
        {
            query = query.Skip(spec.Skip).Take(spec.Take);
        }

        return query;
    }
}