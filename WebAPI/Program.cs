using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Business.Mappings;
using WebNetSample.Core.DependencyResolvers;
using WebNetSample.Core.Extensions;
using WebNetSample.Core.Utilities.IoC;
using WebNetSample.DataAccess;
using WebNetSample.WebAPI.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacDependencyResolver()));

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

var mapperConfig = new MapperConfiguration(config =>
{
    config.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDataAccessServices(builder.Configuration);

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