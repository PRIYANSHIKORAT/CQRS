using CleanArchWithCQRSandMediator.Domain.IReposiotry;
using CleanArchWithCQRSandMediator.Domain.Reposiotry;
using ClearArchWithSQRSandMediator.Infra.Data;
using ClearArchWithSQRSandMediator.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClearArchWithSQRSandMediator.Infra
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructurServices
        (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ??
                    throw new InvalidOperationException("Connection string 'DefaultConnection' not found"));
            });

            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IBlogPostRepository, BlogPostRepository>();
            return services;
        }
    }
}

