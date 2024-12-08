using AppManagement.Entities.Abstract;
using AppManagement.Entities.Concrete.AddressManagement;

namespace AppManagement.Entities.Concrete
{
	public class Office : BaseEntity
	{
		public string Name { get; set; }
		public string ContactNumber { get; set; }
		public Address Address { get; set; }
		public ICollection<Employee> Employees { get; set; }
		public ICollection<Holiday> Holidays { get; set; }
		public ICollection<Appointment> Appointments { get; set; }
	}
}
