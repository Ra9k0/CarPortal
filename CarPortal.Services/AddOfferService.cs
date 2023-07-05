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
			return await dbContext.Makes.Where(make=>make.Models.All(model=>model.CategoryId == categoryId)).Select(m => new MakeViewModel()
			{
				Id = m.Id,
				Name = m.Name
			}).ToListAsync();
		}

        public async Task<IEnumerable<ModelViewModel>> GetModelsByMakeAsync(int makeId)
        {
            var models = await dbContext.Models.Where(m => m.MakeId == makeId).Select(m => new ModelViewModel()
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
	}
}
