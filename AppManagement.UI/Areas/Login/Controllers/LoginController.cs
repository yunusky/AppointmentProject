using AppManagement.UI.Areas.Login.Models;
using AppManagement.UI.Areas.Login.Models.VMs;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppManagement.UI.Areas.Login.Controllers
{
	[Area("Login")]
	public class LoginController(IMapper mapper, INotyfService notyfService, IHttpClientFactory httpClientFactory) : Controller
	{
		private readonly HttpClient _httpClient = httpClientFactory.CreateClient("ApiClient");
		private readonly IMapper _mapper = mapper;
		private readonly INotyfService _notyfService = notyfService;
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM loginVM)
		{
			if (!ModelState.IsValid)
			{
				_notyfService.Error("Email yada Password Hatali.");
				return View(loginVM);
			}


			var loginData = new
			{
				email = loginVM.Email,
				password = loginVM.Password,
				twoFactorCode = loginVM.twoFactorCode,
				twoFactorRecoveryCode = loginVM.twoFactorCodeRecoveryCode
			};

			var jsonContent = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync("/login", jsonContent);

			if (response.IsSuccessStatusCode)
			{
				var responseData = await response.Content.ReadAsStringAsync();
				var token = JsonConvert.DeserializeObject<TokenResponse>(responseData);

				HttpContext.Session.SetString("AuthToken", token.AccessToken);
				return RedirectToAction("Index", "Home", new { Area = "Admin" });
			}

			return RedirectToAction("Index", "Login", new { Area = "Login" });

		}
	}
}
