using AppManagement.DataAccess.Repositories.Abstract;
using AppManagement.Entities.Abstract;

namespace AppManagement.Business.Abstract
{
	public interface IManager<T> : IRepository<T> where T : BaseEntity, IBaseEntity
	{

	}
}
