using System;
using System.Security.Cryptography.X509Certificates;
using CarPortal.Data;
using CarPortal.Data.Models;
using CarPortal.Services.Interfaces;
using CarPortal.Web.ViewModels.AddOffer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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


		public void CreateOffer(AddOfferViewModel offer, Guid userId)
		{
			Car car = new Car()
			{
				ColorId = offer.Car.ColorId,
				ConditionId = offer.Car.ConditionId,
				EngineTypeId = offer.Car.EngineTypeId,
				ManufactureYear = offer.Car.ManufactureYear,
				ModelId = offer.Car.ModelId
			};

			Offer offerForAdd = new Offer()
			{
				Title = offer.Title,
				Description = offer.Description,
				Price = offer.Price,
				OwnerId = userId,
				Car = car,
				Images = GetImages(offer).Result,
				CreatedOn = DateTime.UtcNow
			};

			try
			{
				dbContext.Cars.Add(car);
				dbContext.Offers.Add(offerForAdd);
				dbContext.SaveChanges();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

		}

		private async Task<ICollection<Image>> GetImages(AddOfferViewModel offer)
		{
			List<Image> imagesList = new List<Image>();
			if (offer.ImageFiles != null && offer.ImageFiles.Count > 0)
			{

				foreach (var file in offer.ImageFiles)
				{
					var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

					var filePath = Path.Combine("wwwroot", "OfferImages", fileName); 

					var stream = new FileStream(filePath, FileMode.Create);

					await file.CopyToAsync(stream);
						

					Image image = new Image()
					{
						PhotoPath = $"OfferImages/{fileName}",
					};
					imagesList.Add(image);
				}
			}

			return imagesList;
		}
	}
}
