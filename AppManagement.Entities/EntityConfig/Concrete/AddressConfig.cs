using AppManagement.Entities.Concrete.AddressManagement;
using AppManagement.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppManagement.Entities.EntityConfig.Concrete
{
	public class AddressConfig : BaseConfig<Address>
	{
		public override void Configure(EntityTypeBuilder<Address> builder)
		{
			base.Configure(builder);

			// One-to-One ilişki: Address - Office
			builder.HasOne(a => a.Office)
				.WithOne(b => b.Address)
				.HasForeignKey<Address>(a => a.OfficeId);

		}
	}
}
