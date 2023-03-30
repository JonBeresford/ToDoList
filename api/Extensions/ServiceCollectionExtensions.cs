using api.StorageLayer;
using api.tests.Services;
using EFCoreInMemoryDbDemo;
using Microsoft.Extensions.DependencyInjection;

namespace api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddToDoServices(this IServiceCollection services)
        {
            services.AddDbContext<StorageDbContext>();
            services.AddScoped<IStorageProvider, StorageProvider>();
            services.AddSingleton<IToDoService, ToDoService>();

            return services;
        }

    }
}
