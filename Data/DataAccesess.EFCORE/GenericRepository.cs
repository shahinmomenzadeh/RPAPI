using Microsoft.EntityFrameworkCore;
using userapi.Controllers;

namespace Data.DataAccess.EFCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private DbSet<T> table = null;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        table = _context.Set<T>();
    }
    public void Add(T entity)
    {
        table.Add(entity);
        _context.SaveChanges();
    }
    public IEnumerable<T> GetAll()
    {
        return table.ToList();
    }

    public T GetById(int id)
    {
      return table.Find(id);
    }
    public void Delete(int id)
    {
        var model = table.Find(id);
        table.Remove(model);
        _context.SaveChanges();
    }
    public void Update(T entity)
    {
        table.Update(entity);
        _context.SaveChanges();
    }
}
