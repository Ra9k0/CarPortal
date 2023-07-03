﻿using CarPortal.Web.ViewModels.User;

namespace CarPortal.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<RegionViewModel>> GetRegionsAsync();
    }
}