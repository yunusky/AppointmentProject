using AppManagement.UI.Areas.Login.Models.VMs;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppManagement.UI.Areas.Login.Controllers
{
	[Area("Login")]
	public class RegisterController(IMapper mapper, INotyfService notyfService, IHttpClientFactory httpClientFactory) : Controller
	{
		private readonly HttpClient _httpClient = httpClientFactory.CreateClient("ApiClient");
		private readonly IMapper _mapper = mapper;
		private readonly INotyfService _notyfService = notyfService;

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM registerVM)
		{

			if (!ModelState.IsValid)
			{
				_notyfService.Error("mail yada şifreyi Kontrol edin.");
				return View(registerVM);
			}

			var registerData = new
			{
				email = registerVM.Email,
				password = registerVM.Password,
			};

			return View();
		}
	}
}
