using Castle.DynamicProxy;
using FluentValidation;
using WebNetSample.Core.CrossCuttingConcerns.Validation;
using WebNetSample.Core.Utilities.Interceptors;

namespace WebNetSample.Core.Aspects.Validation;

// Validation implementation as AOP design
public class ValidationAspect : MethodInterception
{
    private readonly Type _validatorType;

    public ValidationAspect(Type validatorType)
    {
        if (!typeof(IValidator).IsAssignableFrom(validatorType))
        {
            throw new Exception("This is not a validation class.");
        }

        _validatorType = validatorType;
    }

    // Implementing validation with FluentValidation before method is executed
    protected override void OnBefore(IInvocation invocation)
    {
        var validator = (IValidator)Activator.CreateInstance(_validatorType);
        var entityType = _validatorType.BaseType.GetGenericArguments()[0];
        var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
        foreach (var entity in entities) ValidationTool.Validate(validator, entity);
    }
}