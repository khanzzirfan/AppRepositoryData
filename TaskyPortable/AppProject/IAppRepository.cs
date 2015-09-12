using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject
{
	public interface IAppRepository<T> where T:new()
	{
		List<T> GetAll();
		T Get(int id);
		int Insert(T entity);
		int Update(T entity);
		int Delete(T entity);
	}
}
