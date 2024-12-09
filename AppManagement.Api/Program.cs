
using AppManagement.DataAccess.DbContexts;
using AppManagement.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AppManagement.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("server=.;database=AppointmentDb;Trusted_Connection=True;TrustServerCertificate=True;"));
			builder.Services.AddIdentityApiEndpoints<AppUser>()
				.AddEntityFrameworkStores<AppDbContext>();
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();
			app.MapIdentityApi<AppUser>();
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
