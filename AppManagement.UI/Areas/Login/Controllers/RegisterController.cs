using AppManagement.UI.Areas.Login.Models.VMs;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppManagement.UI.Areas.Login.Controllers
{
	[Area("Login")]
	public class RegisterController(IMapper mapper, INotyfService notyfService, IHttpClientFactory httpClientFactory) : Controller
	{
		private readonly HttpClient _httpClient = httpClientFactory.CreateClient();//"ApiClient");
		private readonly IMapper _mapper = mapper;
		private readonly INotyfService _notyfService = notyfService;

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM registerVM)
		{
			var model = new
			{
				UserName = registerVM.UserName,
				Email = registerVM.Email,
				FirstName = registerVM.FirstName,
				LastName = registerVM.LastName,
				Password = registerVM.Password,
				ConfirmPassword = registerVM.ConfirmPassword
			};

			var jsonContent = JsonConvert.SerializeObject(model);
			var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

			var response = await _httpClient.PostAsync("http://localhost:5166/api/Register/register", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Login", new { Area = "Login" });
			}
			else
			{
				var errorMessage = await response.Content.ReadAsStringAsync();
				_notyfService.Error($"Kayıt sırasında bir hata oluştu: {errorMessage}");
				return RedirectToAction("Index", "Register", new { Area = "Login" });
			}
		}
	}
}
