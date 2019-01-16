using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
