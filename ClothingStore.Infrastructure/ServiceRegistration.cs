using ClothingStore.Application.Contracts.Persistence;
using ClothingStore.Application.Contracts.Services;
using ClothingStore.Infrastructure.Persistence;
using ClothingStore.Infrastructure.Repositories;
using ClothingStore.Infrastructure.Services.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClothingStore.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClothingStoreDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IEmailService, EmailService>();
            services.Configure<EmailSettings>(configuration.GetSection("Services").GetSection("EmailSettings"));

            return services;
        }
    }
}
