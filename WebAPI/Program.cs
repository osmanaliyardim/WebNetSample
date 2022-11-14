using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using WebNetSample.Business.DependencyResolvers.Autofac;
using WebNetSample.Core.DependencyResolvers;
using WebNetSample.Core.Extensions;
using WebNetSample.Core.Utilities.IoC;
using WebNetSample.DataAccess;
using WebNetSample.WebAPI.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
     options.AddDefaultPolicy(builder =>
     builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacDependencyResolver()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

builder.Services.AddDataAccessServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();