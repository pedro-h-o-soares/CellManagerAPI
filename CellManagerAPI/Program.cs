using CellManagerAPI.Application.Interfaces;
using CellManagerAPI.Application.Services;
using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Services.Services;
using CellManagerAPI.Infraestructure.CrossCutting.Adapter;
using CellManagerAPI.Infraestructure.Data;
using CellManagerAPI.Infraestructure.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var cellDbStrConn = builder.Configuration.GetConnectionString("CellDbConnection");

builder.Services
    .AddDbContext<CellManagerContext>(opts =>
        opts.UseLazyLoadingProxies()
            .UseSqlServer(cellDbStrConn));

Require.RequireAssembly();

builder.Services.AddTransient<IApplicationServiceSupervisions, ApplicationServiceSupervisions>();
builder.Services.AddTransient<IServiceSupervisions, ServiceSupervisions>();
builder.Services.AddTransient<IRepositorySupervisions, RepositorySupervisions>();

builder.Services.AddTransient<IApplicationServiceCells, ApplicationServiceCells>();
builder.Services.AddTransient<IServiceCells, ServiceCells>();
builder.Services.AddTransient<IRepositoryCells, RepositoryCells>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
