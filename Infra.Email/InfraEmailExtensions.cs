using Domain.Ports;
using Infra.Email.Send;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Email
{
    public static class InfraEmailExtensions
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, SendEmailFake>();
            return services;
        }
    }
}
