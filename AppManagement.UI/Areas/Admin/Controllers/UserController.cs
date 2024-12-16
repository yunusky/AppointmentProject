using AppManagement.DataAccess.DbContexts;
using AppManagement.Entities.Concrete;
using AppManagement.UI.Areas.Admin.Models.VMs;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppManagement.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController(INotyfService notyfService,
		IMapper mapper,
		IHostEnvironment hostEnvironment,
		AppDbContext context,
		UserManager<AppUser> userManager,
		RoleManager<AppRole> roleManager
		) : Controller
	{

		//private readonly UserManager<AppUser> _userManager;

		//public UserController(UserManager<AppUser> userManager)
		//{
		//	_userManager = userManager;
		//}

		public async Task<IActionResult> Index()
		{
			var users = await context.Users.ToListAsync();
			return View(users);
		}

		[HttpGet]
		public async Task<IActionResult> UserInsert()
		{

			UserInsertVM userInsertVM = new UserInsertVM();
			var roller = await context.Roles.ToListAsync();

			foreach (var role in roller)
			{
				CheckBoxVM checkBoxVM = new CheckBoxVM()
				{
					Id = role.Id,
					LabelName = role.Name,
					IsChecked = false
				};
				userInsertVM.Roller.Add(checkBoxVM);
			}
			return View(userInsertVM);
		}

		[HttpPost]
		public async Task<IActionResult> UserDelete(int id)
		{
			var user = await context.Users.FirstOrDefaultAsync(p => p.Id == id);
			context.Users.Remove(user);
			await context.SaveChangesAsync();
			return RedirectToAction("Index", "User", new { Area = "Admin" });
		}



		//[HttpPost]
		//public async Task<IActionResult> UserInsert(UserInsertVM insertVM)
		//{

		//	if (!ModelState.IsValid)
		//	{

		//		notyfService.Error("Düzeltilmesi gereken yerler var");
		//		return View(insertVM);
		//	}

		//	#region Fotograf Kaydetme
		//	string uploads = "";
		//	string userImagePAth = "";
		//	if (insertVM.Picture != null
		//		&& (insertVM.Picture.ContentType.Contains("image/jpeg") || insertVM.Picture.ContentType.Contains("image/png")))
		//	{
		//		//Dosya ismin alma 
		//		var fileName = Path.GetFileName(insertVM.Picture.FileName);
		//		//Dosya Extension bulma
		//		var extension = Path.GetExtension(fileName);
		//		//Birlestirme işlemi 
		//		var newFileName = string.Concat(Guid.NewGuid().ToString(), extension);
		//		userImagePAth = $@"/images/{newFileName}";
		//		uploads = Path.Combine(hostEnvironment.ContentRootPath, $@"wwwroot/images/{newFileName}");
		//		string filePath = Path.Combine(uploads, newFileName);
		//		using (var fileStream = new System.IO.FileStream(uploads, FileMode.Create))
		//		{
		//			await fileStream.CopyToAsync(fileStream);
		//		}
		//	}
		//	#endregion
		//	// Burada insertvm MyUser sinifina çevrilmesi lazim

		//	#region Amele Yontemi

		//	MyUser myUser = new MyUser();
		//	myUser.Cinsiyet = insertVM.Cinsiyet;
		//	myUser.Ad = insertVM.Ad;
		//	myUser.Soyad = insertVM.Soyad;
		//	myUser.Email = insertVM.Email;
		//	myUser.TcNo = insertVM.TcNo;
		//	myUser.Gsm = insertVM.Gsm;
		//	myUser.CreateDate = DateTime.Now;
		//	myUser.Password = insertVM.Password;
		//	myUser.PhotoPath = userImagePAth;
		//	#endregion

		//	//var myUser = mapper.Map<MyUser>(insertVM);
		//	try
		//	{
		//		userManager.Create(myUser);
		//		myUser.Roller = new List<Role>();

		//		#region Kullaniciya check edilen rollerin atanmasi
		//		foreach (var item in insertVM.Roller.Where(p => p.IsChecked == true).ToList())
		//		{
		//			var role = roleManager.GetById(item.Id);
		//			myUser.Roller.Add(role);
		//		}
		//		// user role db'den cekilir


		//		userManager.Update(myUser);
		//	}
		//	catch (SqlException sqlException)
		//	{

		//		notyfService.Error("Hata Olustu :" + sqlException.InnerException);
		//		return View(insertVM);
		//	}
		//	catch (Exception ex)
		//	{
		//		var message = ex.InnerException.Message.Split(".")[2];
		//		notyfService.Error("Hata Olustu :" + message);
		//		return View(insertVM);
		//	}

		//	#endregion
		//	notyfService.Success("Islem Basarili");



		//	// userManager.Create(insertVM);

		//	return RedirectToAction("Index", "User", new { Area = "Admin" });

		//}

	}
}
