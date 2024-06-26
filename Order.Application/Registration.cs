using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Features.Orders.Create;
using Order.Application.Features.Orders.Get;
using Order.Application.Features.User.Login;
using Order.Application.Features.Users.Register;
using Order.Application.Validators;

namespace Order.Application
{
    public static class Registration
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

            services.AddScoped<LoginHandler>();
            services.AddScoped<RegisterHandler>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            services.AddMediatR(config => config.RegisterServicesFromAssemblies(assemblies));

            services.AddValidatorsFromAssembly(typeof(CreateOrderCommandValidator).Assembly);

            return services;
        }
    }
}
