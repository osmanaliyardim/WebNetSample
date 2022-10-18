namespace WebNetSample.Core.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreationDate { get; set; }

    public BaseEntity()
    {
    }

    public BaseEntity(Guid id, DateTime creationDate) : this()
    {
        Id = id;
        CreationDate = creationDate;
    }
}