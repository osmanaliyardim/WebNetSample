using Autofac;
using Autofac.Extensions.DependencyInjection;
using WebNetSample.Business;
using WebNetSample.Business.DependencyResolvers.Autofac;
using WebNetSample.Core.DependencyResolvers;
using WebNetSample.Core.Extensions;
using WebNetSample.Core.Utilities.IoC;
using WebNetSample.DataAccess;
using WebNetSample.WebNetMVC.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

builder.Services.AddDataAccessServices(builder.Configuration);

var appSettings = builder.Configuration.ReadAppSettings();
appSettings.Validate();

builder.Services.AddBusinessServices(appSettings);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

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

    options.MapRazorPages();
});

app.Run();