using Microsoft.AspNetCore.Mvc;

namespace AppManagement.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CompanyController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
