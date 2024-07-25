using WebApi.Config;
using WebApi.ExtensionsConfig;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add my services to the container
builder.Services.AddWebApiExtensionsConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Inicializa os dados
DataInitializer.InitializeData(app);

app.UseMiddleware<GlobalErrorMiddlewares>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
