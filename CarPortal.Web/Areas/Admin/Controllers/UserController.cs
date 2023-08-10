using CarPortal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarPortal.Web.Areas.Admin.Controllers
{
	public class UserController : BaseController
	{
		private readonly IUserService userService;

		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		public async Task<IActionResult> All()
		{
			ViewBag.Users = await userService.GetAllUsersAsync();
			return View();
		}
	}
}
