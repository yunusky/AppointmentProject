using Microsoft.AspNetCore.Mvc;

namespace AppManagement.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AppointmentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
