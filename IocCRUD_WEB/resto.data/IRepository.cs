using Resto.Core;
using System.Linq;

namespace Resto.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
