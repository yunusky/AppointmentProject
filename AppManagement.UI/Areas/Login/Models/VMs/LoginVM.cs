using System.ComponentModel.DataAnnotations;

namespace AppManagement.UI.Areas.Login.Models.VMs
{
	public class LoginVM
	{

		[DataType(DataType.EmailAddress)]
		[Required(ErrorMessage = "Email Adresi girilmek zorundadir")]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Şifre  girilmesi zorunludur")]
		public string Password { get; set; }

		public bool RememberMe { get; set; } = false;
		public string twoFactorCode { get; set; } = "0";
		public string twoFactorCodeRecoveryCode { get; set; } = "0";
	}
}
