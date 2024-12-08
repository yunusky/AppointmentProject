using AppManagement.Entities.Abstract;

namespace AppManagement.Entities.Concrete
{
	public class Appointment : BaseEntity
	{
		public int UserID { get; set; }
		public AppUser User { get; set; }
		public int OfficeId { get; set; }
		public Office Office { get; set; }
		public int EmployeeId { get; set; }
		public Employee Employee { get; set; }
		public int StatusId { get; set; }
		public AppointmentStatus Status { get; set; }
	}
}
