using AppManagement.DataAccess.DbContexts;
using AppManagement.DataAccess.Repositories.Abstract;
using AppManagement.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppManagement.DataAccess.Repositories.Concrete
{
	public class Repository<T> : IRepository<T> where T : BaseEntity, IBaseEntity
	{
		private readonly AppDbContext db;

		public Repository(AppDbContext db)
		{
			this.db = db;
		}
		public async virtual Task<int> CreateAsync(T entity)
		{
			db.Set<T>().Add(entity);
			return await db.SaveChangesAsync();
		}

		public async virtual Task<int> DeleteAsync(T entity)
		{
			db.Set<T>().Remove(entity);
			return await db.SaveChangesAsync();
		}

		public async virtual Task<List<T>?> GetAllAsync(Expression<Func<T, bool>> predicate = null)
		{
			if (predicate != null)
			{
				return await db.Set<T>().Where(predicate).ToListAsync();
			}
			return await db.Set<T>().ToListAsync();

		}

		public async virtual Task<IQueryable<T>?> GetAllIncludeAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] include)
		{
			IQueryable<T> query = db.Set<T>();
			if (predicate != null)
			{
				query = db.Set<T>().Where(predicate);
			}
			return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
		}

		public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
		{
			if (predicate != null)
			{
				return await db.Set<T>().FirstOrDefaultAsync(predicate);
			}
			return await db.Set<T>().FirstOrDefaultAsync();
		}

		public async virtual Task<T?> GetByIdAsync(string id)
		{
			return await db.Set<T>().FindAsync(id);
		}

		public async virtual Task<int> UpdateAsync(T entity)
		{
			db.Set<T>().Update(entity);
			return await db.SaveChangesAsync();
		}
	}
}

