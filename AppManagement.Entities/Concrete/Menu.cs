using AppManagement.Entities.Abstract;

namespace AppManagement.Entities.Concrete
{
	public class Menu : BaseEntity
	{

		public string MenuName { get; set; }
		public string? ActionName { get; set; }
		public string? ControllerName { get; set; }
		public string? AreaName { get; set; }
		public string? ClassName { get; set; }
		public string? CssName { get; set; }
		public string? IConName { get; set; }

		public int? OrderNo { get; set; }
		public int? ParentMenuId { get; set; }
		public Menu? ParentMenu { get; set; }
	}
}
