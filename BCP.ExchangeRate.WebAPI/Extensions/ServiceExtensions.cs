using BCP.ExchangeRate.BusinessLogic;
using BCP.ExchangeRate.BusinessLogic.ExchangeRate;
using BCP.ExchangeRate.BusinessLogic.ExchangeRate.Interface;
using BCP.ExchangeRate.BusinessLogic.Interfaces;
using BCP.ExchangeRate.Repository.ExchangeRate;
using BCP.ExchangeRate.Repository.Redis.ExchangeRate;
using Microsoft.Extensions.DependencyInjection;

namespace BCP.ExchangeRate.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();
        }

        public static void ConfigureServicesManager(this IServiceCollection services)
        {
            services.AddScoped<IExchangeRateBL, ExchangeRateBL>();
            services.AddScoped<IUserBL, UserBL>();
        }
    }
}