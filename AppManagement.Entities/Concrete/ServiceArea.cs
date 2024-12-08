namespace AppManagement.Entities.Concrete
{
	public class ServiceArea
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Company> Companies { get; set; }
	}
}
