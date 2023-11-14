using Microsoft.EntityFrameworkCore;
using ProjectPractice.API;
using ProjectPractice.API.Extensions;
using ProjectPractice.Application.Services.Custom;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Services.Custom;
using System.Diagnostics;

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



//TEST ENTITY F 7-- END
/*Stopwatch timeMeasure = new Stopwatch();

var options = new DbContextOptionsBuilder<BdBillContext>()
    .UseNpgsql("Server=localhost;Port=5432;Database=bd_bill;User ID=postgres;Password=jav123;")
    .Options;

using (var context =new BdBillContext(options))
{
    timeMeasure.Start();
    await context.Brands.Where(e => e.BrandName == "Mercedes-Benz").ExecuteUpdateAsync( e => e.SetProperty(t => t.BrandStatus, t => true));
    await context.Brands.Where(e => e.BrandName == "Mercedes-Benz" && e.BrandId != 4).ExecuteDeleteAsync();

    var list = context.Brands.Where(e => e.BrandName == "Mercedes-Benz").ToList();
    list.ForEach(e => e.BrandStatus = false);
    await context.SaveChangesAsync();
    timeMeasure.Stop();
    Console.WriteLine($"Time: {timeMeasure.Elapsed.TotalMilliseconds} ms");
} // FINALLY
*/
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


