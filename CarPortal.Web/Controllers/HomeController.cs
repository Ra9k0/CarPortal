using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CarPortal.Data.Models;
using System.Security.Cryptography;
using Microsoft.Extensions.Hosting;

namespace CarPortal.Web.Controllers
{
    public class HomeController : BaseController
    {

		private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
		{
			this.homeService = homeService;
		}

		[AllowAnonymous]
        public async Task<IActionResult> Index()
        {
	        if (User.IsInRole("Admin"))
	        {
		        return RedirectToAction("Index", "Home", new { area = "Admin" });
	        }
	        if (User.Identity.IsAuthenticated)
            {
	            IEnumerable<OfferViewModel> offersAuth = await homeService.GetOffersAsyncByRegion(Guid.Parse(GetUserId()));
				ApplicationUser? user = await homeService.GetApplicationUserAsync(Guid.Parse(GetUserId()));
                if (user != null && offersAuth.Any())
				{
                    ViewBag.InfoMessage = $"The most recent offers in {homeService.GetRegionAsync(user.RegionId).Result.Name}!";
                }
                else
                {
					ViewBag.InfoMessage = $"The most recent offers!";
				}
                return View(offersAuth);
            }
            ViewBag.InfoMessage = $"The most recent offers!";
			IEnumerable<OfferViewModel>  offersNotAuth = await homeService.GetOffersAsync();
            return View(offersNotAuth);
		}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}