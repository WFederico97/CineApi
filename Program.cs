using Microsoft.EntityFrameworkCore;
using RepasoParcialCine.Entities;
using RepasoParcialCine.Repositories.Implementations;
using RepasoParcialCine.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<cineContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); //Inyeccion de db de EF

builder.Services.AddScoped<ICineRepository, CineRepository>(); // crea instancia por cada request // inyeccion de dependencias


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
