using AppManagement.Entities.Abstract;

namespace AppManagement.Entities.Concrete
{
	public class Company : BaseEntity
	{
		public string Name { get; set; }
		public int ServiceAreaId { get; set; }
		public ServiceArea ServiceArea { get; set; }
		public ICollection<Office> Offices { get; set; }
	}
}
