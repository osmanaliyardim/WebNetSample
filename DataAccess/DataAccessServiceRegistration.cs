using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.DataAccess.Concrete.EntityFramework;
using WebNetSample.DataAccess.Concrete.EntityFramework.Contexts;

namespace WebNetSample.DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
                                                            IConfiguration configuration)
    {
        services.AddDbContext<WebNetSampleDBContext>(options =>
                                                 options.UseSqlServer(
                                                     configuration.GetConnectionString("WebNetSampleConnectionStringForWindows")));

        services.AddDefaultIdentity<IdentityUser>
            (options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
        .AddEntityFrameworkStores<WebNetSampleDBContext>();

        services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
            .AddAzureAD(options =>
            {
                configuration.Bind("AzureAd", options);
                options.CookieSchemeName = IdentityConstants.ApplicationScheme;
            });

        services.AddSingleton<ISupplierRepository, EfSupplierRepository>();
        services.AddSingleton<IProductRepository, EfProductRepository>();
        services.AddSingleton<ICategoryRepository, EfCategoryRepository>();

        return services;
    }
}