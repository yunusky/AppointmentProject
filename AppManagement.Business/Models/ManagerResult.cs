namespace AppManagement.Business.Models
{
	public class ManagerResult
	{

		public bool Success { get; set; } = true;
		public List<MyError> Errors { get; set; } = new();

	}

	public class MyError
	{
		public string Key { get; init; }
		public string Value { get; init; }
		public MyError(string key, string value)
		{
			Key = key;
			Value = value;
		}
	}
}
