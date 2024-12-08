using AppManagement.Entities.Abstract;

namespace AppManagement.Entities.Concrete
{
	public class Holiday : BaseEntity
	{
		public string Name { get; set; } // Tatil adı (örn: Yılbaşı, Bayram)
		public string Description { get; set; } // Tatilin Açıklaması
		public DateTime StartDate { get; set; } // Tatilin başlangıç tarihi
		public DateTime EndDate { get; set; } // Tatilin bitiş tarihi
		public bool IsRecurring { get; set; } // Tatil her yıl tekrarlanıyor mu?
		public ICollection<Office> Offices { get; set; } // Ofis ile ilişki
	}
}
