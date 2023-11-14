using Microsoft.EntityFrameworkCore;
using Teste.Seguro.Data.Context;
using Teste.Seguro.Data.Repository;
using Teste.Seguro.Domain.Interface.Repository;
using Teste.Seguro.Domain.Interface.Service;
using Teste.Seguro.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// DI
builder.Services.AddScoped<ISeguroService, SeguroService>();
builder.Services.AddScoped<ISeguroRepository, SeguroRepository>();
builder.Services.AddScoped<ISeguradoService, SeguradoService>();
builder.Services.AddScoped<ISeguradoRepository, SeguradoRepository>();
builder.Services.AddScoped<ISeguradoraService, SeguradoraService>();
builder.Services.AddScoped<ISeguradoraRepository, SeguradoraRepository>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["connectionString"]);
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/errors");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.MapControllers();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();