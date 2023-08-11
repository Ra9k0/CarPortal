using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPortal.Data;
using CarPortal.Data.Models;
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
					Car = new Car()
					{
						Color = of.Car.Color,
						Condition = of.Car.Condition,
						EngineType = of.Car.EngineType,
						ManufactureYear = of.Car.ManufactureYear,
						Model = new Model()
						{
							Category = of.Car.Model.Category,
							Make = of.Car.Model.Make,
							Name = of.Car.Model.Name,
						}
					},
					Owner = new ApplicationUser()
					{
						FirstName = of.Owner.FirstName,
						LastName = of.Owner.LastName,
						PhoneNumber = of.Owner.PhoneNumber,
						Region = of.Owner.Region,
					},
				}).FirstAsync(of => of.Id == Guid.Parse(offerId));
		}

		public async Task EditOfferAsync(OfferEditViewModel offer)
		{
			var offerForEdit = await dbContext.Offers.FindAsync(offer.Id);

			Car car = new Car()
			{
				EngineTypeId = offer.Car.EngineTypeId,
				ConditionId = offer.Car.ConditionId,
				ColorId = offer.Car.ColorId,
				ModelId = offer.Car.ModelId,
				ManufactureYear = offer.Car.ManufactureYear,
			};

			if (offerForEdit != null)
			{
				offerForEdit.Title = offer.Title;
				offerForEdit.Description = offer.Description;
				offerForEdit.Price = offer.Price;
				offerForEdit.Car = car;
			}
			await dbContext.SaveChangesAsync();
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

		public async Task<OfferEditViewModel> GetOfferForEditByIdAsync(string offerId, string userId,bool isAdmin)
		{
			var offer = await dbContext.Offers.Select(of =>
				new OfferEditViewModel()
				{
					Id = of.Id,
					Price = of.Price,
					Description = of.Description,
					Title = of.Title,
					Car = new CarViewModel()
					{
						ColorId = of.Car.ColorId,
						ModelId = of.Car.ModelId,
						ConditionId = of.Car.ConditionId,
						EngineTypeId = of.Car.EngineTypeId,
						ManufactureYear = of.Car.ManufactureYear
					},
					Model = of.Car.Model,
					MakeName = of.Car.Model.Make.Name,
					CategoryName = of.Car.Model.Category.Name,
					ColorName = of.Car.Color.Name,
					ConditionName = of.Car.Condition.Name,
					EngineTypeName = of.Car.EngineType.Type,
					OwnerId = of.OwnerId,

				}).FirstAsync(of => of.Id == Guid.Parse(offerId));
			if (!isAdmin)
			{
				if (offer == null)
				{
					throw new InvalidOperationException($"Offer with ID {offerId} not found.");
				}

				if (offer.OwnerId != Guid.Parse(userId))
				{
					throw new UnauthorizedAccessException("You are not authorized to access this offer.");
				}
			}

			return offer;

		}

		public async Task Delete(string offerId, string userId, bool isAdmin)
		{
			var offer = await dbContext.Offers.FindAsync(Guid.Parse(offerId));
			if (offer.OwnerId != Guid.Parse(userId))
			{
				if (!isAdmin)
				{
					throw new UnauthorizedAccessException("You are not authorized to delete this offer.");
				}
			}
			dbContext.Remove(offer);
			await dbContext.SaveChangesAsync();
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
