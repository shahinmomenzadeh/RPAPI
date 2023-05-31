namespace userapi.Controllers;

public interface IGenericRepository<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
    T GetById(int id);
     IEnumerable<T> GetAll();

}
