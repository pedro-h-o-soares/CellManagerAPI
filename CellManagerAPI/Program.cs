using CellManagerAPI.Application.Interfaces;
using CellManagerAPI.Application.Services;
using CellManagerAPI.Domain.Core.Interfaces.Repositories;
using CellManagerAPI.Domain.Core.Interfaces.Services;
using CellManagerAPI.Domain.Services.Services;
using CellManagerAPI.Infraestructure.CrossCutting.Adapter;
using CellManagerAPI.Infraestructure.Data;
using CellManagerAPI.Infraestructure.Repository.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var cellDbStrConn = builder.Configuration.GetConnectionString("CellDbConnection");

builder.Services
    .AddDbContext<CellManagerContext>(opts =>
        opts.UseLazyLoadingProxies()
            .UseSqlServer(cellDbStrConn)
            .EnableSensitiveDataLogging());

builder.Services
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<CellManagerContext>();

Require.RequireAssembly();

builder.Services.AddTransient<IApplicationServiceSupervisions, ApplicationServiceSupervisions>();
builder.Services.AddTransient<IServiceSupervisions, ServiceSupervisions>();
builder.Services.AddTransient<IRepositorySupervisions, RepositorySupervisions>();

builder.Services.AddTransient<IApplicationServiceCells, ApplicationServiceCells>();
builder.Services.AddTransient<IServiceCells, ServiceCells>();
builder.Services.AddTransient<IRepositoryCells, RepositoryCells>();

builder.Services.AddTransient<IApplicationServiceMembers, ApplicationServiceMembers>();
builder.Services.AddTransient<IServiceMembers, ServiceMembers>();
builder.Services.AddTransient<IRepositoryMembers, RepositoryMembers>();

builder.Services.AddTransient<IApplicationServiceVisitors, ApplicationServiceVisitors>();
builder.Services.AddTransient<IServiceVisitors, ServiceVisitors>();
builder.Services.AddTransient<IRepositoryVisitors, RepositoryVisitors>();

builder.Services.AddTransient<IApplicationServiceEvents, ApplicationServiceEvents>();
builder.Services.AddTransient<IServiceEvents, ServiceEvents>();
builder.Services.AddTransient<IRepositoryEvents, RepositoryEvents>();

builder.Services.AddTransient<IApplicationServiceAuth, ApplicationServiceAuth>();

builder.Services.AddTransient<IApplicationServiceUsers, ApplicationServiceUsers>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var info = new OpenApiInfo()
{
    Title = "CellManagerAPI Documentation",
    Version = "v1",
    Description = "This project implements a API for managing groups of people and events from a organization",
    Contact = new OpenApiContact()
    {
        Name = "Pedro Soares",
        Email = "p.h.o.soares@hotmail.com",
    }

};

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", info);

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
