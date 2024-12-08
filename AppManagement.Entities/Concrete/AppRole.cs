using AppManagement.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace AppManagement.Entities.Concrete
{
	public class AppRole : IdentityRole<int>, IBaseEntity
	{
	}
}
