using Microsoft.EntityFrameworkCore;
using WoofLodge.Api;
using WoofLodge.Api.Data;
using WoofLodge.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<DatabaseInitializer>();
builder.Services.AddScoped<IBreedService, BreedService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WoofLodgeDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WoofLodgeConnection"));
}); 

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();

seeder.Seed();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
