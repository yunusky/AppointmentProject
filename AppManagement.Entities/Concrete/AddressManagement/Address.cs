using AppManagement.Entities.Abstract;

namespace AppManagement.Entities.Concrete.AddressManagement
{
	public class Address : BaseEntity
	{
		public int StreetID { get; set; }
		public int BuildingNumber { get; set; } //Bina numarası
		public int ApartmentNumber { get; set; } //Daire numarası
		public string PostalCode { get; set; } // Posta Kodu
		public string Description { get; set; } //Adres tarifi, opsiyonel
		public double? Latitude { get; set; } // Enlem
		public double? Longitude { get; set; } // Boylam

		public ICollection<AppUser> UserAddress { get; set; }
		public int OfficeId { get; set; }
		public Office Office { get; set; }
	}
}
