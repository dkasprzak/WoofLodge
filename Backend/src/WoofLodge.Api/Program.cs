using Microsoft.EntityFrameworkCore;
using WoofLodge.Api;
using WoofLodge.Api.Data;
using WoofLodge.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IBreedService, BreedService>();
builder.Services.AddScoped<IDogService, DogService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPostgres(builder.Configuration);

//Add this line to listen on port 80
#if !DEBUG
    builder.WebHost.UseUrls("http://*:80");
#endif

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
