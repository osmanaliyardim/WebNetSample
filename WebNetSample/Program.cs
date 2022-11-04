using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Mappings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using WebNetSample.Business.DependencyResolvers.Autofac;
using WebNetSample.Core.DependencyResolvers;
using WebNetSample.Core.Extensions;
using WebNetSample.Core.Utilities.IoC;
using WebNetSample.DataAccess;
using WebNetSample.WebNetMVC.Middlewares;
using WebNetSample.Entity.Concrete;
using WebNetSample.WebNetMVC.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

builder.Services.AddDependencyResolvers(
    new ICoreModule[]
        {
            new CoreModule()
        });

builder.Services.AddDataAccessServices(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.ConfigureCustomExceptionMiddleware();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.UseResponseCaching();

app.UseEndpoints(options =>
{
    options.MapControllerRoute(
        name: "images",
        pattern: "images/{id}",
        new { controller = "Categories", action = "GetImageById" });

    options.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();