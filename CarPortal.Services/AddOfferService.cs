using CarPortal.Data;
using CarPortal.Data.Models;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.AddOffer;
using Microsoft.EntityFrameworkCore;

namespace CarPortal.Services
{
	public class AddOfferService : IAddOfferService
	{
		private readonly CarPortalDbContext dbContext;

		public AddOfferService(CarPortalDbContext dbContext)
		{
			this.dbContext = dbContext;
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

        public async Task<IEnumerable<ModelViewModel>> GetAllModelsAsync()
        {
            return await dbContext.Models.Select(c => new ModelViewModel()
            {
                Id = c.Id,
                Name = c.Name,
				CategoryId = c.CategoryId,
				Category = c.Category,
				MakeId = c.MakeId,
				Make = c.Make
            }).ToListAsync();
        }


        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
		{
			return await dbContext.Categories.Select(c => new Category()
			{
				Id = c.Id,
				Name = c.Name,
			}).ToListAsync();
		}

		public async Task<IEnumerable<EngineTypeViewModel>> GetAllEngineTypes()
		{
			return await dbContext.EngineTypes.Select(et => new EngineTypeViewModel
			{
				Id = et.Id,
				Type = et.Type
			}).ToListAsync();
		}

		public async Task<IEnumerable<ColorViewModel>> GetAllColors()
		{
			return await dbContext.Colors.Select(c => new ColorViewModel
			{
				Id = c.Id,
				Name = c.Name
			}).ToListAsync();
        }

		public async Task<IEnumerable<ConditionViewModel>> GetAllConditions()
		{
			return await dbContext.Conditions.Select(c => new ConditionViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();
        }

		public async Task CreateOffer(AddOfferViewModel offer, Guid userId)
		{
			Guid offerId = Guid.NewGuid();

			if (offer.ImageFiles != null && offer.ImageFiles.Count > 0)
			{

				foreach (var file in offer.ImageFiles)
				{
					// Generate a unique filename or use any desired logic
					var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

					// Specify the path where the images will be saved
					var filePath = Path.Combine("OfferImages", fileName);

					// Save the file to the server
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await file.CopyToAsync(stream);
					}

					Image image = new Image()
					{
						OfferId = offerId,
						PhotoPath = "/images/" + fileName,
					};
					await dbContext.AddAsync(image);
				}
			}

			Car car = new Car()
			{
				ColorId = offer.Car.ColorId,
				ConditionId = offer.Car.ConditionId,
				EngineTypeId = offer.Car.EngineTypeId,
				ManufactureYear = offer.Car.ManufactureYear,
				ModelId = offer.Car.ModelId
			};
			await dbContext.Cars.AddAsync(car);
			await dbContext.SaveChangesAsync();


			Offer offerForAdd = new Offer()
			{
				Id = offerId,
				Title = offer.Title,
				Description = offer.Description,
				Price = offer.Price,
				CarId = dbContext.Cars.LastAsync().Id,
				OwnerId = userId
			};

			await dbContext.Offers.AddAsync(offerForAdd);
			await dbContext.SaveChangesAsync();
		}
	}
}
