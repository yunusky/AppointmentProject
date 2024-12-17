using AppManagement.DataAccess.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace AppManagement.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class MenusController : Controller
	{

		public IActionResult Index()
		{
			AppDbContext context = new AppDbContext();
			var menus = context.Menus.ToList();
			return View(menus);
		}
	}
}
