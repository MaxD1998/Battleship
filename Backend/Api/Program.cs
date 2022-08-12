using Api.Middlewares;
using Core.Interfaces.Services;
using Core.Services;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

service.AddControllers();
service.AddDbContext<DataContext>();

service.AddScoped<IRandomPositionGeneratorService, RandomPositionGeneratorService>();
service.AddScoped<IShipGeneratorService, ShipGeneratorService>();

service.AddEndpointsApiExplorer();
service.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("http://localhost:4200"));

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<DataContext>();
context.Database.Migrate();

app.Run();