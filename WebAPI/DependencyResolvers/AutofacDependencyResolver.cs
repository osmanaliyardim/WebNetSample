using Autofac;
using WebNetSample.Business.Abstract;
using WebNetSample.Business.Concrete;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.DataAccess.Concrete.EntityFramework;

namespace WebNetSample.WebAPI.DependencyResolvers;

public class AutofacDependencyResolver : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
        builder.RegisterType<EfProductRepository>().As<IProductRepository>().SingleInstance();

        builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
        builder.RegisterType<EfCategoryRepository>().As<ICategoryRepository>().SingleInstance();
    }
}