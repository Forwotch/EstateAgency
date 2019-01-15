using EstateAgency.API.Services.ApartmentOwners;
using EstateAgency.API.Services.Apartments;
using EstateAgency.API.Services.RentAnnouncements;
using EstateAgency.API.Services.SaleAnnouncements;
using EstateAgency.Authentification;
using EstateAgency.Authentification.Services;
using EstateAgency.BLL.Announcements.Services;
using EstateAgency.BLL.ApartmentOwners.Services;
using EstateAgency.BLL.Apartments.Services;
using EstateAgency.BLL.RentAnnouncements.Services;
using EstateAgency.BLL.SaleAnnouncements.Services;
using EstateAgency.DAL.EF;
using EstateAgency.DAL.UnitOfWork;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EstateAgency.API
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection ResolveDalDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection ResolveServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRentAnnouncementService, RentAnnouncementService>();
            services.AddScoped<IRentAnnouncementResponseComposer, RentAnnouncementResponseComposer>();
            services.AddScoped<IRentAnnouncementExpressionComposer, RentAnnouncementExpressionComposer>();
            services.AddScoped<IRentAnnouncementCreator, RentAnnouncementCreator>();

            services.AddScoped<ISaleAnnouncementService, SaleAnnouncementService>();
            services.AddScoped<ISaleAnnouncementResponseComposer, SaleAnnouncementResponseComposer>();
            services.AddScoped<ISaleAnnouncementExpressionComposer, SaleAnnouncementExpressionComposer>();
            services.AddScoped<ISaleAnnouncementCreator, SaleAnnouncementCreator>();

            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IApartmentResponseComposer, ApartmentResponseComposer>();
            services.AddScoped<IApartmentCreator, ApartmentCreator>();

            services.AddScoped<IApartmentOwnerService, ApartmentOwnerService>();
            services.AddScoped<IApartmentOwnerResponseComposer, ApartmentOwnerResponseComposer>();

            services.AddScoped<IAnnouncementService, AnnouncementService>();

            services.AddScoped<IAuthentificationService, AuthentificationService>();

            return services;
        }

        public static IServiceCollection ResolveIdentityDependencies(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            return services;
        }

        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Estate Agency API",
                    Version = "v1"
                });
                c.IncludeXmlComments(
                    @"bin\Debug\netcoreapp2.0\EstateAgency.API.xml");
            });

            return services;
        }
    }
}