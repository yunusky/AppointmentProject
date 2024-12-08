using AppManagement.Entities.Concrete;
using AppManagement.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppManagement.Entities.EntityConfig.Concrete
{
	public class AppointmentConfig : BaseConfig<Appointment>
	{
		public override void Configure(EntityTypeBuilder<Appointment> builder)
		{
			base.Configure(builder);
			builder.Property(a => a.Status)
			.HasConversion<int>();


			builder.HasOne(a => a.User)
			  .WithMany()
			  .HasForeignKey(a => a.UserID);

			builder.HasOne(x => x.Office)
				.WithMany(y => y.Appointments)
				.HasForeignKey(x => x.OfficeId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(x => x.Employee)
				.WithMany(y => y.Appointments)
				.HasForeignKey(x => x.EmployeeId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
