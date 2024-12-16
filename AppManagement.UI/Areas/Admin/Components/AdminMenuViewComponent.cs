using AppManagement.Business.Abstract;
using AppManagement.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AppManagement.UI.Areas.Admin.Components
{
	public class AdminMenuViewComponent : ViewComponent
	{
		private readonly IManager<Menu> menuManager;

		public AdminMenuViewComponent(IManager<Menu> menuManager)
		{
			this.menuManager = menuManager;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var menuler = await menuManager.GetAllAsync();
			return View(menuler);
		}
	}
}
