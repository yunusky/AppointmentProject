using AppManagement.Entities.Abstract;
using System.Linq.Expressions;

namespace AppManagement.DataAccess.Repositories.Abstract
{
	public interface IRepository<T> where T : BaseEntity, IBaseEntity
	{
		public Task<int> CreateAsync(T entity);
		public Task<int> UpdateAsync(T entity);
		public Task<int> DeleteAsync(T entity);

		public Task<T?> GetByIdAsync(string id);
		public Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
		public Task<List<T>?> GetAllAsync(Expression<Func<T, bool>> predicate = null);

		public Task<IQueryable<T>?> GetAllIncludeAsync(Expression<Func<T, bool>> predicate = null
			, params Expression<Func<T, object>>[] include);

	}
}
