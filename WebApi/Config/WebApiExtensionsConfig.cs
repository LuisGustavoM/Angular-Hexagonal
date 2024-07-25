using Infra.Data;
using Infra.Email;
using Application;

namespace WebApi.ExtensionsConfig
{
    public static class WebApiExtensionsConfig
    {
        public static IServiceCollection AddWebApiExtensionsConfig(this IServiceCollection services)
        {
            services.AddDataBaseInMemoryService();
            services.AddEmailService();
            services.AddApplicationService();

            return services;
        }
    }
}