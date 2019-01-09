using AutoMapper;
using EstateAgency.API.Services;
using EstateAgency.BLL.RentAnnouncements.Services;
using EstateAgency.DAL.EF;
using EstateAgency.DAL.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EstateAgency")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRentAnnouncementService, RentAnnouncementService>();
            services.AddScoped<IRentAnnouncementResponseComposer, RentAnnouncementResponseComposer>();
            
            RegisterSwagger(services);
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estate Agency API v1"));

            app.UseMvc();
        }

        public IServiceCollection RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Estate Agency API",
                    Version = "v1"
                });
            });

            return services;
        }
    }
}
