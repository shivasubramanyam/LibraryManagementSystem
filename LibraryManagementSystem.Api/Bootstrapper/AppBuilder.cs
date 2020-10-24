using LibraryManagementSystem.Api.Services;
using LibraryManagementSystem.Core.DataContext;
using LibraryManagementSystem.Core.Helpers;
using LibraryManagementSystem.Core.Interfaces;
using LibraryManagementSystem.Repository.DataRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Api.Bootstrapper
{
    public static class AppBuilder
    {
        public static IServiceCollection RegisterCustomAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookFacilitator, BookFacilitator>();
            services.AddScoped<IBookReviewService, BookReviewService>();
            services.AddDbContext<AppContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Database:ConnectionString")));
            services.AddScoped<IDapper, DapperHelper>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookReviewRepository, BookReviewRepository>();

            return services;
        }
    }
}
