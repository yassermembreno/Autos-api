using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infraestructure.Data;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MarcaAutoDbContext>(options => options.UseNpgsql(builder.Configuration
                                                                                       .GetConnectionString("Default")));
builder.Services.AddScoped<IMarcaAutoRepository, MarcaAutoRepository>();
builder.Services.AddScoped<IMarcaAutosService, MarcaAutoService>();

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
