using System.Collections.Generic;
namespace TaskyPortableLibrary
{
	public interface IRepository<T> where T:new()
	{
		List<T> GetAll();
		T GetById(int id);
		int Insert(T entity);
		int Delete(T entity);
	}
}
