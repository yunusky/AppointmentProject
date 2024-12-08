using AppManagement.Entities.Abstract;

namespace AppManagement.Entities.Concrete
{
	public class Gender : BaseEntity
	{
		public string Name { get; set; }
		public ICollection<AppUser> Users { get; set; }
	}
}
