using LibraryManagementSystem.Api.DataAccess;
using LibraryManagementSystem.Api.Interfaces;
using LibraryManagementSystem.Api.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LibraryManagementSystem.Api.Bootstrapper
{
    public static class AppBuilder
    {
        public static IServiceCollection LoadAppConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var appDirectory = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
            var configurationBuilder = new ConfigurationBuilder();
            var addedConfiguration = configurationBuilder
                .SetBasePath(appDirectory)
                .AddJsonFile("Database/Users.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            services.Replace(ServiceDescriptor.Singleton(typeof(IConfiguration), addedConfiguration));

            return services;
        }

        public static IServiceCollection RegisterCustomAppServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserDataAccess, UserDataAccess>();

            return services;
        }
    }
}
