using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPortal.Data;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.Home;
using CarPortal.Web.ViewModels.Offer;
using Microsoft.EntityFrameworkCore;

namespace CarPortal.Services
{
	public class OfferService : IOfferService
	{
		private readonly CarPortalDbContext dbContext;

		public OfferService(CarPortalDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<OfferDetailsViewModel> GetOfferByIdAsync(string offerId)
		{
			return await dbContext.Offers.Select(of =>
				new OfferDetailsViewModel()
				{
					Id = of.Id,
					CarId = of.CarId,
					Images = of.Images,
					Price = of.Price,
					CreatedOn = of.CreatedOn,
					Description = of.Description,
					Title = of.Title,
					OwnerId = of.OwnerId,
					Car = of.Car,
					Owner = of.Owner
				}).FirstAsync(of => of.Id == Guid.Parse(offerId));
		}
	}
}
