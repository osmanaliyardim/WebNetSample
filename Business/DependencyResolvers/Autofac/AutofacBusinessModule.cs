using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Module = Autofac.Module;
using System.Reflection;
using WebNetSample.Business.Abstract;
using WebNetSample.Business.Concrete;
using WebNetSample.Core.Utilities.Interceptors;
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

        var assembly = Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions { Selector = new AspectInterceptorSelector() })
            .SingleInstance();
    }
}