using AppManagement.Business.Abstract;
using AppManagement.Business.Concrete;

namespace AppManagement.UI.Extensions
{
	public static class TicariExtensions
	{
		public static IServiceCollection AddTicariService(this IServiceCollection services)
		{

			services.AddScoped(typeof(IManager<>), typeof(Manager<>));

			return services;
		}
	}
}
