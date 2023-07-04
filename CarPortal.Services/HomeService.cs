
using CarPortal.Data;
using CarPortal.Data.Models;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.Home;
using Microsoft.EntityFrameworkCore;

namespace CarPortal.Services
{
	public class HomeService : IHomeService
	{
		private readonly CarPortalDbContext dbContext;

		public HomeService(CarPortalDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<OfferViewModel>> GetOffersAsync(Guid id)
		{
			ApplicationUser user = await GetApplicationUserAsync(id) ?? new ApplicationUser();

				return await dbContext.Offers.Where(of => of.Owner.RegionId == user.RegionId).Select(of =>
					new OfferViewModel()
					{
						Id = of.Id,
						CarId = of.CarId,
						Images = of.Images,
						Price = of.Price,
						CreatedOn = of.CreatedOn,
						Description = of.Description,
						Title = of.Title
					}).Take(3).OrderByDescending(of=>of.CreatedOn).ToListAsync();
		}
		 
		public async Task<ApplicationUser?> GetApplicationUserAsync(Guid id)
		{
			ApplicationUser? user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
			
			return user;
			
		}

        public async Task<Region?> GetRegionAsync(int id)
        {
            Region? region = await dbContext.Regions.FirstOrDefaultAsync(u => u.Id == id);

            return region;

        }
    }
}
