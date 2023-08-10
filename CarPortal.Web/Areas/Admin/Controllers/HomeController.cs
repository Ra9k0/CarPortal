using Microsoft.AspNetCore.Mvc;

namespace CarPortal.Web.Areas.Admin.Controllers
{
	public class HomeController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
