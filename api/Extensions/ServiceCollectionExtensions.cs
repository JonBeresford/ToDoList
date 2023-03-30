using api.StorageLayer;
using api.tests.Services;
using EFCoreInMemoryDbDemo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTwilio(this IServiceCollection services)
        {
            services.AddDbContext<StorageDbContext>();
            services.AddScoped<IStorageProvider, StorageProvider>();
            services.AddSingleton<IToDoService, ToDoService>();

            return services;
        }

    }
}
