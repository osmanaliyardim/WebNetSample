using Autofac;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.DataAccess.Concrete.EntityFramework;
using WebNetSample.Business.Abstract;
using WebNetSample.Business.Concrete;

namespace WebNetSample.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
        builder.RegisterType<EfProductRepository>().As<IProductRepository>().SingleInstance();

        builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
        builder.RegisterType<EfCategoryRepository>().As<ICategoryRepository>().SingleInstance();

        builder.RegisterType<SupplierManager>().As<ISupplierService>().SingleInstance();
        builder.RegisterType<EfSupplierRepository>().As<ISupplierRepository>().SingleInstance();
    }
}