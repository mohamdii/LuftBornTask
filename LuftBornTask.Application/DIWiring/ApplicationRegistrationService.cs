using FluentValidation;
using LuftBornTask.Application.Interfaces;
using LuftBornTask.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace LuftBornTask.Application.DIWiring
{
    public static class ApplicationRegistrationService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            services.AddScoped<IProductService, ProductService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<LuftBornTask.Application.ValidationFactories.IValidatorFactory, LuftBornTask.Application.ValidationFactories.ValidatorFactory>();

            return services;
        }
    }
}
