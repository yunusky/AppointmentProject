using AppManagement.Entities.Concrete;
using AppManagement.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppManagement.Entities.EntityConfig.Concrete
{
	public class CompanyConfig : BaseConfig<Company>
	{
		public override void Configure(EntityTypeBuilder<Company> builder)
		{
			base.Configure(builder);
			builder.Property(x => x.Name).HasMaxLength(100);



		}
	}
}
