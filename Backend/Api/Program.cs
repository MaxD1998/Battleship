using Core.Interfaces.Services;
using Core.Services;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

service.AddScoped<IRandomPositionGeneratorService, RandomPositionGeneratorService>();

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

app.Run();