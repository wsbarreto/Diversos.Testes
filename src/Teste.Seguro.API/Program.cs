using Microsoft.EntityFrameworkCore;
using Teste.Seguro.Data.Context;
using Teste.Seguro.Data.Repository;
using Teste.Seguro.Domain.Interface.Repository;
using Teste.Seguro.Domain.Interface.Service;
using Teste.Seguro.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// injection dependency
builder.Services.AddScoped<ISeguroService, SeguroService>();
builder.Services.AddScoped<ISeguroRepository, SeguroRepository>();
builder.Services.AddScoped<ISeguradoService, SeguradoService>();
builder.Services.AddScoped<ISeguradoRepository, SeguradoRepository>();
builder.Services.AddScoped<ISeguradoraService, SeguradoraService>();
builder.Services.AddScoped<ISeguradoraRepository, SeguradoraRepository>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();



builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("connectionString"));

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
