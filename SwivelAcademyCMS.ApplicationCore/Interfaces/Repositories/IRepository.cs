using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.ApplicationCore.Interfaces.Repositories
{
	public interface IRepository<T> where T : class
	{
		Task<T> Find(int id);
		Task<IEnumerable<T>> GetAll();
		Task Add(T entity);
		void Remove(T entity);
		void Update(T entity);
	}
}
