namespace WebNetSample.Core.Entities;

public class BaseDto
{
    public Guid Id { get; set; }

    public BaseDto()
    {
    }

    public BaseDto(Guid id) : this()
    {
        Id = id;
    }
}