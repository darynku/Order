using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Order.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Order.Infrastructure.Providers;
using Order.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Order.Infrastructure.Options;
namespace Order.Infrastructure
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructure
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Jwt));

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                options.TokenValidationParameters = new()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!))
                });

            services.AddAuthentication();
            services.AddAuthorization();

            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();

            return services;
        }
    }
}
