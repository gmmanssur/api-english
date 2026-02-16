using ApiEnglish.Application.DTOs.Auth;
using ApiEnglish.Application.Validator;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace ApiEnglish.Application.Config
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(RegisterRequest).Assembly));
            services.AddValidatorsFromAssembly(typeof(RegisterCommandValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            
            return services;
        }
    }
}
