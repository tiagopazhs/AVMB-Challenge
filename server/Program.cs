using server.Services;
using server.Infraestructure.Repository;
using server.Services.AntiCorruption;
using server.Domain.Interfaces.Service;
using server.Domain.Interfaces.Service.AntiCorruption;
using server.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositoryService, RepositoryService>();
builder.Services.AddScoped<IEnvelopeService, EnvelopeService>();
builder.Services.AddScoped<IEnvelopeAntiCorruptionService, EnvelopeAntiCorruptionService>();
builder.Services.AddScoped<IFolderService, FolderService>();

builder.Services.AddScoped<IEnvelopeRepository, EnvelopeRepository>();

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
