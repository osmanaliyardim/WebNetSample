using Castle.DynamicProxy;

namespace WebNetSample.Core.Utilities.Interceptors;

// Valid for both classes and methods and allows multiple aspect definitin
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
{
    public int Priority { get; set; } // To order aspects

    public virtual void Intercept(IInvocation invocation)
    {
    }
}