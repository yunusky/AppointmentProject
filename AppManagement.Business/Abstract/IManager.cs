using AppManagement.Business.Models;
using AppManagement.DataAccess.DbContexts;
using AppManagement.DataAccess.Repositories.Abstract;
using AppManagement.Entities.Abstract;

namespace AppManagement.Business.Abstract
{
	public interface IManager<T> : IRepository<T> where T : BaseEntity
	{
		public AppDbContext Db { get; init; }

		public Task<ManagerResult> CreateAsync(T entity);
		public Task<ManagerResult> UpdateAsync(T entity);
		public Task<ManagerResult> DeleteAsync(T entity);
	}
}
