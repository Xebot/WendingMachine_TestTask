using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WendingDomain;
using AppServices.Interfaces;
using AppServices.Services;
using WendingDomain.RepositoryInterfaces;
using WendingDomain.Data.Repositories;


namespace ServiceCollectionExtensions{
    

    public static class ServiceCollectionExtensions
    {
        
        public static IServiceCollection AddDependencyInjection (this IServiceCollection services, string connectionString)
        {
            var str = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={connectionString};Integrated Security=True;Connect Timeout=30";
            services.AddDbContext<WendingDbContext>(options => options.UseSqlServer(str));
            services.AddTransient<IDrinkService, DrinkService>();
            services.AddTransient<IDrinksRepository, DrinksRepository>();
            services.AddTransient<IWendingMachineRepository, WendingMachineRepository>();
            services.AddTransient<IWendingMachineService, WendingMachineService>();
            services.AddTransient<ICoinRepository, CoinRepository>();
            services.AddTransient<IHelpService, HelpService>();
            services.AddTransient<ICoinStorageRepository, CoinStorageRepository>();
            
            return services;
        }
    }
}
