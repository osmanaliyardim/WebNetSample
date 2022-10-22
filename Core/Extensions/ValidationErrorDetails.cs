using FluentValidation.Results;

namespace WebNetSample.Core.Extensions;

public class ValidationErrorDetails : ErrorDetails
{
    public IEnumerable<ValidationFailure> Errors { get; set; }
}