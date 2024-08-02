using Autofac.Extensions.DependencyInjection;
using Autofac;
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
using CellManagerAPI.Infraestructure.CrossCutting.Adapter.AutoMapper;

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

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((container) =>
    {
        container.RegisterType<ApplicationServiceSupervisions>().As<IApplicationServiceSupervisions>().InstancePerLifetimeScope();
        container.RegisterType<ServiceSupervisions>().As<IServiceSupervisions>().InstancePerLifetimeScope();
        container.RegisterType<RepositorySupervisions>().As<IRepositorySupervisions>().InstancePerLifetimeScope();

        container.RegisterType<ApplicationServiceCells>().As<IApplicationServiceCells>().InstancePerLifetimeScope();
        container.RegisterType<ServiceCells>().As<IServiceCells>().InstancePerLifetimeScope();
        container.RegisterType<RepositoryCells>().As<IRepositoryCells>().InstancePerLifetimeScope();

        container.RegisterType<ApplicationServiceMembers>().As<IApplicationServiceMembers>().InstancePerLifetimeScope();
        container.RegisterType<ServiceMembers>().As<IServiceMembers>().InstancePerLifetimeScope();
        container.RegisterType<RepositoryMembers>().As<IRepositoryMembers>().InstancePerLifetimeScope();

        container.RegisterType<ApplicationServiceVisitors>().As<IApplicationServiceVisitors>().InstancePerLifetimeScope();
        container.RegisterType<ServiceVisitors>().As<IServiceVisitors>().InstancePerLifetimeScope();
        container.RegisterType<RepositoryVisitors>().As<IRepositoryVisitors>().InstancePerLifetimeScope();

        container.RegisterType<ApplicationServiceEvents>().As<IApplicationServiceEvents>().InstancePerLifetimeScope();
        container.RegisterType<ServiceEvents>().As<IServiceEvents>().InstancePerLifetimeScope();
        container.RegisterType<RepositoryEvents>().As<IRepositoryEvents>().InstancePerLifetimeScope();

        container.RegisterType<ApplicationServiceAuth>().As<IApplicationServiceAuth>().InstancePerLifetimeScope();

        container.RegisterType<ApplicationServiceUsers>().As<IApplicationServiceUsers>().InstancePerLifetimeScope();
    });

var assembly = typeof(ProfileCells).Assembly;
builder.Services.AddAutoMapper(assembly);

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
