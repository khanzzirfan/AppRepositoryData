using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RestoCore
{
	public interface IRepository<T> where T : new()
	{
		List<T> GetItems();
		T GetItem(int id);
		int SaveItem(T entity);
		void SaveItems (IEnumerable<T> items);
		int DeleteItem(T entity);
		T Get(Expression<Func<T, bool>> predicate);
		List<T> FindById(int id);
		int CountTable();

	}
}

