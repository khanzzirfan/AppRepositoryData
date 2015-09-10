using System.Collections.Generic;
namespace CoreRepository
{
    public interface IRepository<T> where T : new()
    {
        List<T> GetItems();
        T GetItem(int id);
        int SaveItem(T entity);
        int DeleteItem(T entity);
    }
}
