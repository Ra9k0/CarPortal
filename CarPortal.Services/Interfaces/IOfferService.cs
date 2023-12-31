﻿using CarPortal.Data.Models;
using CarPortal.Web.ViewModels.Home;
using CarPortal.Web.ViewModels.Offer;

namespace CarPortal.Services.Interfaces
{
    public interface IOfferService
	{
		Task<IEnumerable<OfferViewModel>> GetAllOffersAsync();
		Task<OfferDetailsViewModel> GetOfferByIdAsync(string offerId);

		Task EditOfferAsync(OfferEditViewModel offer);

		Task<IEnumerable<MakeViewModel>> GetMakesByCategoryAsync(int categoryId);

		Task<IEnumerable<Category>> GetAllCategoriesAsync();

		Task<IEnumerable<ModelViewModel>> GetAllModelsAsync();

		Task<IEnumerable<ModelViewModel>> GetModelsByMakeAsync(int makeId, int categoryId);

		Task<IEnumerable<EngineTypeViewModel>> GetAllEngineTypes();

		Task<IEnumerable<ColorViewModel>> GetAllColors();

		Task<IEnumerable<ConditionViewModel>> GetAllConditions();

		void CreateOffer(AddOfferViewModel offer, Guid userId);

		Task<OfferEditViewModel> GetOfferForEditByIdAsync(string offerId, string id, bool isAdmin);
		Task Delete(string offerId, string id, bool isAdmin);
	}
}
