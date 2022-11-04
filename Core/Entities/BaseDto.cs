namespace WebNetSample.Core.Entities;

public record BaseDto
{
    public Guid Id { get; }

    public BaseDto()
    {
    }

    public BaseDto(Guid id) : this()
    {
        Id = id;
    }
}