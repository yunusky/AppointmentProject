using AppManagement.Entities.Concrete;
using AppManagement.Entities.EntityConfig.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppManagement.Entities.EntityConfig.Concrete
{
	public class MenuConfig : BaseConfig<Menu>
	{
		public override void Configure(EntityTypeBuilder<Menu> builder)
		{
			base.Configure(builder);
			builder.Property(p => p.MenuName).HasMaxLength(50);
			builder.Property(p => p.ActionName).HasMaxLength(50);
			builder.Property(p => p.ControllerName).HasMaxLength(50);
			builder.Property(p => p.AreaName).HasMaxLength(50);
			builder.Property(p => p.CssName).HasMaxLength(500);
			builder.Property(p => p.IConName).HasMaxLength(500);

			builder.HasData(new Menu
			{
				Id = 1,
				MenuName = "Home",
				ControllerName = "Home",
				ActionName = "Index",
				AreaName = "Admin",
				ClassName = "far fa-circle nav-icon",
				CssName = ""

			},
			 new Menu
			 {
				 Id = 3,
				 MenuName = "Kullanicilar",
				 ControllerName = "Account",
				 ActionName = "Index",
				 AreaName = "Admin",
				 ClassName = "far fa-circle nav-icon",
				 CssName = ""

			 });


		}
	}
}
