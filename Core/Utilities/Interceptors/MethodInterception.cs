using Castle.DynamicProxy;

namespace WebNetSample.Core.Utilities.Interceptors;

// Method interceptions to invoke methods you want at all states
public abstract class MethodInterception : MethodInterceptionBaseAttribute
{
    // Before method is executed
    protected virtual void OnBefore(IInvocation invocation)
    {
    }

    // After method is executed
    protected virtual void OnAfter(IInvocation invocation)
    {
    }

    // When an error ocurred while method is executing
    protected virtual void OnException(IInvocation invocation, Exception e)
    {
    }

    // When method is executed successfully
    protected virtual void OnSuccess(IInvocation invocation)
    {
    }

    // At all condition (whenever method is executing)
    public override void Intercept(IInvocation invocation)
    {
        var isSuccess = true;
        OnBefore(invocation); // Before execution
        try
        {
            invocation.Proceed(); // At run time
        }
        catch (Exception e)
        {
            isSuccess = false;
            OnException(invocation, e); // When an error occured
            throw;
        }
        finally
        {
            if (isSuccess) OnSuccess(invocation); // When everything is ok
        }
        OnAfter(invocation); // After execution
    }
}