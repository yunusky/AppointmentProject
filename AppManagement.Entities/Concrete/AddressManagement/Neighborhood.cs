using AppManagement.Entities.Abstract;

namespace AppManagement.Entities.Concrete.AddressManagement
{
	public class Neighborhood : BaseEntity
	{
		public int DistrictId { get; set; }
		public string Name { get; set; }
	}
}
