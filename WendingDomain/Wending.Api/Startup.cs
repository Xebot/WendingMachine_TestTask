using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceCollectionExtensions;
using WendingDomain.AutomapperProfiles;

namespace Wending.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            connectionString = env.ContentRootPath+"\\App_data\\WendingDb.mdf";
        }

        public IConfiguration Configuration { get; }
        public string connectionString { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {                      
            AutoMapperInitializer.Initialize();
            services.AddAutoMapper();            
            services.AddDependencyInjection(connectionString);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var connectionString = env.ContentRootPath;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
