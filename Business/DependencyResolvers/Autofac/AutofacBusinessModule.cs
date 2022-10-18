using Autofac;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.DataAccess.Concrete.EntityFramework;
using WebNetSample.Business.Abstract;
using WebNetSample.Business.Concrete;
using WebNetSample.Core.Pagination;

namespace WebNetSample.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();

        builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();

        builder.RegisterType<SupplierManager>().As<ISupplierService>().SingleInstance();

        builder.RegisterType<PaginationParameter>().As<PaginationParameters>().SingleInstance();
    }
}