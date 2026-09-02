using LuftBornTask.Application.Interfaces;
using LuftBornTask.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LuftBornTask.Application.DIWiring
{
    public static class ApplicationRegistrationService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            services.AddScoped<IProductService, ProductService>();  
            // Register application services here
            // Example: services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
