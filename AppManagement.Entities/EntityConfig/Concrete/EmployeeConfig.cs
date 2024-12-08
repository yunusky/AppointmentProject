using AppManagement.Entities.Concrete;
using AppManagement.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppManagement.Entities.EntityConfig.Concrete
{
	public class EmployeeConfig : BaseConfig<Employee>
	{
		public override void Configure(EntityTypeBuilder<Employee> builder)
		{
			base.Configure(builder);

			builder.HasOne(e => e.User)
			   .WithMany()
			   .HasForeignKey(e => e.UserId)
			   .HasPrincipalKey(u => u.Id);
		}
	}
}
