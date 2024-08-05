using WebApi.Config;
using WebApi.ExtensionsConfig;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureFluentValidator();
builder.Services.AddWebApiExtensionsConfig();

var app = builder.Build();

// registra middleware global
app.UseMiddleware<GlobalErrorMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.UseSwaggerConfiguration();

// Inicializa os dados
DataInitializer.InitializeData(app);

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors(option => option.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());

app.MapControllers();

app.Run();
