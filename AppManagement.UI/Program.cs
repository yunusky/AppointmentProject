using AppManagement.UI.MyProfile;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;

namespace AppManagement.UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddAutoMapper(p => p.AddProfile<AutoMapperProfile>());
			builder.Services.AddHttpClient("ApiClient", client =>
			{
				// API'nin temel adresi
				client.BaseAddress = new Uri("http://localhost:5166");
				//client.DefaultRequestHeaders.Add("Accept", "application/json"); // Gerekirse header ekleyin
			});
			builder.Services.AddNotyf(p =>
			{
				p.Position = NotyfPosition.BottomRight;
				p.DurationInSeconds = 7;
				p.IsDismissable = true;

			});
			builder.Services.AddSession();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseNotyf();
			app.UseRouting();
			app.UseSession();
			app.UseAuthentication(); //Burada ki siralama onemli
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
				  name: "areas",
				  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);
			});

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
