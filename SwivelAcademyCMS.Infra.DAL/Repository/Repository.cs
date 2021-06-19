using Microsoft.EntityFrameworkCore;
using SwivelAcademyCMS.ApplicationCore.Interfaces.Repositories;
using SwivelAcademyCMS.Infra.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwivelAcademyCMS.Infra.DAL.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		protected readonly SwivelDbContext _dbContext;
		private DbSet<T> dbSet;
		public Repository(SwivelDbContext dbContext)
		{
			_dbContext = dbContext;
			dbSet = _dbContext.Set<T>();
		}
		public async Task Add(T entity)
		{
			await dbSet.AddAsync(entity);
		}

		public async Task<T> Find(int id)
		{
			return await dbSet.FindAsync(id);
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			return await dbSet.ToListAsync();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void Update(T entity)
		{
			dbSet.Update(entity);
		}

	}
}
