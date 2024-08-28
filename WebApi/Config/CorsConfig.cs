namespace WebApi.Config
{
    public static class CorsConfig
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

        }

        public static void UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
        }
    }
}
