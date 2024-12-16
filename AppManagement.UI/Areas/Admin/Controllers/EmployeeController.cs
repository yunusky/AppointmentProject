using Microsoft.AspNetCore.Mvc;

namespace AppManagement.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class EmployeeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
