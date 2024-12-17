using Microsoft.AspNetCore.Mvc;

namespace AppManagement.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CalenderController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult SpecialSchedule()
		{

			return View();
		}
	}
}
