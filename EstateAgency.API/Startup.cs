using AutoMapper;
using EstateAgency.API.Services;
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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace EstateAgency.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(option =>
                option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.ResolveDalDependencies(Configuration.GetConnectionString("EstateAgency"));
            services.ResolveServicesDependencies();
            services.ResolveIdentityDependencies(Configuration.GetConnectionString("EstateAgencyAuthentification"));
            services.RegisterSwagger();

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estate Agency API v1"));

            app.UseMvc();
        }
    }
}
