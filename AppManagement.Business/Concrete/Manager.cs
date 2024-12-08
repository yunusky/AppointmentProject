using AppManagement.Business.Abstract;
using AppManagement.Business.Models;
using AppManagement.DataAccess.DbContexts;
using AppManagement.DataAccess.Repositories.Concrete;
using AppManagement.Entities.Abstract;

namespace AppManagement.Business.Concrete
{
	public class Manager<T> : Repository<T>, IManager<T> where T : BaseEntity
	{
		public AppDbContext Db { get; init; }
		ManagerResult result;
		public Manager(AppDbContext db) : base(db)
		{
			this.Db = db;
			result = new ManagerResult();
		}

		public async virtual Task<ManagerResult> CreateAsync(T entity)
		{

			var sonuc = await base.CreateAsync(entity);
			if (sonuc == 0)
			{
				result.Success = false;
				result.Errors.Add(new MyError("", "Kayıt Eklenemedi"));
			}
			return result;
		}

		public async virtual Task<ManagerResult> UpdateAsync(T entity)
		{
			var sonuc = await base.UpdateAsync(entity);
			if (sonuc == 0)
			{
				result.Success = false;
				result.Errors.Add(new MyError("", "Kayıt Guncellenemedi"));
			}
			return result;
		}

		public async virtual Task<ManagerResult> DeleteAsync(T entity)
		{
			var sonuc = await base.DeleteAsync(entity);
			if (sonuc == 0)
			{
				result.Success = false;
				result.Errors.Add(new MyError("", "Kayıt Silinemedi"));
			}
			return result;
		}
	}
}
