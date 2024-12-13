using AutoMapper;

namespace AppManagement.UI.MyProfile
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			// UserInsertVM => MyUser'a cevir , ReverseMap ile bu islemin terside dogrudur demek istiyoruz
			//CreateMap<UserInsertVM, MyUser>().ReverseMap();
		}
	}
}
