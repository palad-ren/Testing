using System.Collections.Generic;

public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    object Get(T obj);
    void Delete(T obj);
    void Save(T obj);
}
