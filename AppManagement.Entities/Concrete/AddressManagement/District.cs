using AppManagement.Entities.Abstract;

namespace AppManagement.Entities.Concrete.AddressManagement
{
	public class District : BaseEntity
	{
		public int CityId { get; set; }
		public string Name { get; set; }
	}
}
