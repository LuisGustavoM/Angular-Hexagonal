using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

internal static class SwaggerConfigurationHelpers
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        // Configurando o serviço de documentação do Swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Arquitetura Hexagonal",
                    Description = "Aplicação Net Core 8 - Arquitetura Hexagonal",
                });

            string caminhoXmlDoc = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"{PlatformServices.Default.Application.ApplicationName}.xml");
            c.IncludeXmlComments(caminhoXmlDoc);

            c.IncludeXmlComments(caminhoXmlDoc);
        });
    }
    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
            c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Arquitetura Hexagonal Net Core");
        });
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}