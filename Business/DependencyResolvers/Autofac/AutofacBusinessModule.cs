using Autofac;
using WebNetSample.Business.Abstract;
using WebNetSample.Business.Concrete;
using WebNetSample.Core.Pagination;
using System.Reflection;
using Castle.DynamicProxy;
using WebNetSample.Core.Utilities.Interceptors;
using Autofac.Extras.DynamicProxy;
using Module = Autofac.Module;

namespace WebNetSample.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();

        builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();

        builder.RegisterType<SupplierManager>().As<ISupplierService>().SingleInstance();

        builder.RegisterType<PaginationParameter>().As<PaginationParameters>().SingleInstance();

        var assembly = Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions { Selector = new AspectInterceptorSelector() })
            .SingleInstance();
    }
}