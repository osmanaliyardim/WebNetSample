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

        services.AddSingleton<ISupplierRepository, EfSupplierRepository>();
        services.AddSingleton<IProductRepository, EfProductRepository>();
        services.AddSingleton<ICategoryRepository, EfCategoryRepository>();

        return services;
    }
}