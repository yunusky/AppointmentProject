using AppManagement.Entities.Concrete;
using AppManagement.Entities.Concrete.AddressManagement;
using AppManagement.Entities.EntityConfig.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppManagement.DataAccess.DbContexts
{
	public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
	{
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Holiday> Holidays { get; set; }
		public DbSet<Office> Offices { get; set; }
		//public DbSet<OfficeSchedule> Schedules { get; set; }
		public DbSet<ServiceArea> ServiceAreas { get; set; }


		//Adresler
		public DbSet<Address> Addresses { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<District> Districts { get; set; }
		public DbSet<Neighborhood> Neighborhoods { get; set; }
		public DbSet<Street> Streets { get; set; }



		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		public AppDbContext()
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("server=.;database=AppointmentDb;Trusted_Connection=True;TrustServerCertificate=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder); // IdentityPaketi Kullanilacak ise bu satir olmali
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseConfig<>).Assembly);
		}
	}
}
