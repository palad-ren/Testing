using System.Collections.Generic;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private Util _util = null;
    public GenericRepository()
    {
        this._util = new Util();
    }
    public IEnumerable<T> GetAll()
    {
        return null;
    }
    public object Get(T obj)
    {
        return _util.Read(obj);
    }
    public void Delete(T obj)
    {
        _util.Clear(obj);
    }
    public void Save(T obj)
    {
        _util.Write(obj);
    }
}
