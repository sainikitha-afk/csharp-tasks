using System.Collections.Generic;
using System.Linq;

public class InMemoryRepository<T> : IRepository<T> where T : class
{
    private readonly List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public List<T> GetAll()
    {
        return _items;
    }

    public T GetById(int id)
    {
        return _items.FirstOrDefault(item => (int)item.GetType().GetProperty("Id").GetValue(item) == id);
    }

    public void Update(int id, T updatedItem)
    {
        var item = GetById(id);
        if (item != null)
        {
            _items.Remove(item);
            _items.Add(updatedItem);
        }
    }

    public void Delete(int id)
    {
        var item = GetById(id);
        if (item != null)
        {
            _items.Remove(item);
        }
    }
}