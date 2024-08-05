using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;

namespace WebApi.Config
{
    internal static class FluentValidatorConfig
    {
        public static void ConfigureFluentValidator(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            var assembly = Assembly.GetEntryAssembly();
            services.AddValidatorsFromAssembly(Assembly.GetEntryAssembly());
        }
    }
}
