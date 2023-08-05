using CarPortal.Data;
using CarPortal.Data.Models;
using CarPortal.Services;
using CarPortal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CarPortal.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<CarPortalDbContext>(options =>
                options.UseSqlServer(connectionString),ServiceLifetime.Scoped);
           
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<CarPortalDbContext>();
            
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IHomeService, HomeService>();
            builder.Services.AddScoped<IAddOfferService, AddOfferService>();
            builder.Services.AddScoped<IFilterCarService, FilterCarService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IOfferService, OfferService>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            app.Run();
        }
    }
}