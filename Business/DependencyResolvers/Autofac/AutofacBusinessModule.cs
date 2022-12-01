using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Module = Autofac.Module;
using System.Reflection;
using WebNetSample.Business.Abstract;
using WebNetSample.Business.Concrete;
using WebNetSample.Core.Utilities.Interceptors;
using WebNetSample.Core.CrossCuttingConcerns.Caching;
using WebNetSample.Core.CrossCuttingConcerns.Caching.Microsoft;
using AutoMapper;
using Business.Mappings;
using WebNetSample.Business.Startup;

namespace WebNetSample.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();

        builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();

        builder.RegisterType<SupplierManager>().As<ISupplierService>().SingleInstance();
        
        builder.RegisterType<MemoryCacheManager>().As<ICacheService>().SingleInstance();

        builder.RegisterType<EmailManager>().As<IEmailService>().SingleInstance();

        var mapperConfig = new MapperConfiguration(config =>
        {
            config.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        builder.RegisterInstance(mapper).SingleInstance();

        var assembly = Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions { Selector = new AspectInterceptorSelector() })
            .SingleInstance();
    }
}