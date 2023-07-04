using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CarPortal.Data.Models;
using System.Security.Cryptography;

namespace CarPortal.Web.Controllers
{
    public class HomeController : BaseController
    {

		private readonly IHomeService homeService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IHomeService homeService, UserManager<ApplicationUser> userManager)
		{
			this.homeService = homeService;
            this.userManager = userManager;
		}

		[AllowAnonymous]
        public async Task<IActionResult> Index()
        {
	        IEnumerable<OfferViewModel> offer = new List<OfferViewModel>();
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser? user = await homeService.GetApplicationUserAsync(Guid.Parse(GetUserId()));
                offer = await homeService.GetOffersAsync(Guid.Parse(GetUserId()));
                if (user != null)
                {
                    ViewBag.UserRegion = homeService.GetRegionAsync(user.RegionId).Result.Name;
                }
            }

	        return View(offer);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}