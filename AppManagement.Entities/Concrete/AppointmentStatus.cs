namespace AppManagement.Entities.Concrete
{
	public enum AppointmentStatus
	{
		Scheduled = 1,  // Planlandı
		Pending = 2,    // Beklemede
		Completed = 3,  // Tamamlandı
		Cancelled = 4,  // İptal Edildi
		Rescheduled = 5,// Ertelendi
		NoShow = 6      // Gelmedi
	}
}
