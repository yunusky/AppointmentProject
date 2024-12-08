using AppManagement.Entities.Abstract;

namespace AppManagement.Entities.Concrete.AddressManagement
{
	public class Street : BaseEntity
	{
		public int NeighBorhood { get; set; }
		public string Name { get; set; }
	}
}
