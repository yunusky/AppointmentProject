using AppManagement.Entities.Abstract;

namespace AppManagement.Business.Dtos
{
	public class UserRegisterDto : IBaseEntity
	{
		public string Email { get; set; }
		public string TcNo { get; set; }
		public string Password { get; set; }
	}
}
