using AppManagement.Entities.Abstract;

namespace AppManagement.Entities.Concrete
{
	public class Employee : BaseEntity
	{
		public int UserId { get; set; }
		public AppUser User { get; set; }
		public int OfficeId { get; set; }
		public Office Office { get; set; }
		public ICollection<Appointment> Appointments { get; set; }
	}
}
