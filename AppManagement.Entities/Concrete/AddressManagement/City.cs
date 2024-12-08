using AppManagement.Entities.Abstract;

namespace AppManagement.Entities.Concrete.AddressManagement
{
	public class City : BaseEntity
	{
		public int CountryId { get; set; }
		public string Name { get; set; }
	}
}
