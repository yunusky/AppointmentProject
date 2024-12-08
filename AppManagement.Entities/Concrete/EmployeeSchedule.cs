using AppManagement.Entities.Abstract;

namespace AppManagement.Entities.Concrete
{
	public class EmployeeSchedule : BaseEntity
	{
		public int EmployeeId { get; set; }
		public Employee Employee { get; set; }
		public string Name { get; set; }
		public ICollection<Schedule> Schedules { get; set; }
	}
}
