using AppManagement.DataAccess.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace AppManagement.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AppointmentController : Controller
	{
		public IActionResult Index()
		{
			AppDbContext context = new AppDbContext();
			var appointments = context.Appointments.ToList();
			return View(appointments);
		}


	}
}
