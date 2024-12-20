﻿using AppManagement.Entities.Abstract;
using AppManagement.Entities.Concrete.AddressManagement;
using Microsoft.AspNetCore.Identity;

namespace AppManagement.Entities.Concrete
{
	public class AppUser : IdentityUser<int>, IBaseEntity
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public int? GenderId { get; set; }
		public Gender? Gender { get; set; }
		public ICollection<Address> Addresses { get; set; }
	}
}
