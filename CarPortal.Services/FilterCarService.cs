using CarPortal.Data;
using CarPortal.Data.Models;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.FilterCar;
using CarPortal.Web.ViewModels.Home;
using CarPortal.Web.ViewModels.Offer;
using CarPortal.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace CarPortal.Services
{
    public class FilterCarService : IFilterCarService
	{
		private readonly CarPortalDbContext dbContext;

		public FilterCarService(CarPortalDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<OfferViewModel>> GetAllOffersAsync()
		{
			return await dbContext.Offers.Select(of =>
				new OfferViewModel()
				{
					Id = of.Id,
					CarId = of.CarId,
					Images = of.Images.First(),
					Price = of.Price,
					CreatedOn = of.CreatedOn,
					Description = of.Description,
					Title = of.Title,
					OwnerId = of.OwnerId,
					Car = of.Car,
					Owner = of.Owner
				}).OrderByDescending(of => of.CreatedOn).ToListAsync();
		}

		public async Task<IEnumerable<Category>> GetCategoriesAsync()
		{
			return await dbContext.Categories.Select(c => new Category()
			{
				Id = c.Id,
				Name = c.Name,
			}).ToListAsync();
		}

		public async Task<IEnumerable<MakeViewModel>> GetMakesByCategoryAsync(int categoryId)
		{
			var makes = await dbContext.Models.Where(m => m.CategoryId == categoryId).Select(m => new MakeViewModel()
			{
				Id = m.Make.Id,
				Name = m.Make.Name,
			}).ToListAsync();

			return makes;
		}

		public async Task<IEnumerable<ModelViewModel>> GetModelsByMakeAsync(int makeId, int categoryId)
		{
			var models = await dbContext.Models.Where(m => m.MakeId == makeId && m.CategoryId == categoryId).Select(m => new ModelViewModel()
			{
				Id = m.Id,
				Name = m.Name,
				CategoryId = m.CategoryId,
				Category = m.Category,
				MakeId = m.MakeId,
				Make = m.Make
			}).ToListAsync();
			return models;
		}
		public async Task<IEnumerable<EngineTypeViewModel>> GetAllEngineTypesAsync()
		{
			return await dbContext.EngineTypes.Select(et => new EngineTypeViewModel
			{
				Id = et.Id,
				Type = et.Type
			}).ToListAsync();
		}

		public async Task<IEnumerable<ColorViewModel>> GetAllColorsAsync()
		{
			return await dbContext.Colors.Select(c => new ColorViewModel
			{
				Id = c.Id,
				Name = c.Name
			}).ToListAsync();
		}

		public async Task<IEnumerable<ConditionViewModel>> GetAllConditionsAsync()
		{
			return await dbContext.Conditions.Select(c => new ConditionViewModel
			{
				Id = c.Id,
				Name = c.Name
			}).ToListAsync();
		}

		public async Task<IEnumerable<RegionViewModel>> GetAllRegionsAsync()
		{
			return await dbContext.Regions.Select(r => new RegionViewModel()
			{
				Id = r.Id,
				Name = r.Name
			}).ToListAsync();
		}

		public async Task<IEnumerable<OfferViewModel>> FilteredOffers(FilterCarViewModel offer,string orderer)
		{
			IEnumerable<OfferViewModel> offers = await dbContext.Offers.Where(o => (offer.Car.Model.CategoryId == 0 || o.Car.Model.CategoryId == offer.Car.Model.CategoryId) &&
					(offer.Car.Model.MakeId == 0 || o.Car.Model.MakeId == offer.Car.Model.MakeId) &&
					(offer.Car.ModelId == 0 || o.Car.ModelId == offer.Car.ModelId) &&
					(offer.Car.EngineTypeId == 0 || o.Car.EngineTypeId == offer.Car.EngineTypeId) &&
					(offer.Car.ColorId == 0 || o.Car.ColorId == offer.Car.ColorId) &&
					(offer.Car.ConditionId == 0 || o.Car.ConditionId == offer.Car.ConditionId) &&
					(offer.Car.ManufactureYear == null || o.Car.ManufactureYear >= offer.Car.ManufactureYear) &&
					(offer.Price == null || o.Price <= offer.Price) &&
					(offer.RegionId == 0 || o.Owner.RegionId == offer.RegionId))
				.Select(o => new OfferViewModel()
				{
					Id = o.Id,
					Title = o.Title,
					Price = o.Price,
					Images = o.Images.First(),
					CreatedOn = o.CreatedOn,
				}).ToListAsync();

			if (orderer == "PriceAscending")
			{
				return offers.OrderBy(o => o.Price);
			}
			else if (orderer == "PriceDescending")
			{
				return offers.OrderByDescending(o => o.Price);
			}
			else if (orderer == "CreatedOnAscending")
			{
				return offers.OrderBy(o => o.CreatedOn);
			}

			return offers.OrderByDescending(o => o.CreatedOn);
		}
	}
}
