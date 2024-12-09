using Microsoft.EntityFrameworkCore;
using Animals.Infrastructure.Data;
using Animals.Core.Maps;
using Animals.Core.Interfaces;
using Animals.Repositories;
using Animals.Core.Services;
using Animals.Core.Factories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddAutoMapper(typeof(AnimalProfile));
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IAnimalMapper, AnimalMapper>();
builder.Services.AddScoped<IAnimalFactory, AnimalFactory>();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AnimalsDbContext>((options)=> options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseRouting();

app.Run();