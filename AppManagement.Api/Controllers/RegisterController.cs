using AppManagement.Api.DTOs.Request;
using AppManagement.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RegisterController : ControllerBase
{
	private readonly UserManager<AppUser> _userManager;

	public RegisterController(UserManager<AppUser> userManager)
	{
		_userManager = userManager;
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register(MyRegisterRequest model)
	{
		if (model.Password != model.ConfirmPassword)
		{
			return BadRequest(new { Error = "Passwords do not match." });
		}

		var user = new AppUser
		{
			UserName = model.UserName,
			Email = model.Email,
			FirstName = model.FirstName,
			LastName = model.LastName
		};

		var result = await _userManager.CreateAsync(user, model.Password);

		if (!result.Succeeded)
		{
			return BadRequest(result.Errors.Select(e => e.Description));
		}

		return Ok(new { Message = "User registered successfully." });
	}

}
