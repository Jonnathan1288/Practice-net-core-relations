using Microsoft.EntityFrameworkCore;
using ProjectPractice.API;
using ProjectPractice.API.Extensions;
using ProjectPractice.Application.Services.Custom;
using ProjectPractice.Domain.Interfaces.Services.Custom;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Custom services sorted alphabetically.
// Singleton
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
#endregion

//ADD INYECTION
//DependencyInjectionSystem.AddServices(builder.Services);
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

//ADD MIDDLEWARE --------------
app.ConfigureExceptionMiddleware();

app.MapControllers();

app.Run();
