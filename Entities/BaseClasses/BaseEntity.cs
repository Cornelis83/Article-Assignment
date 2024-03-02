namespace Entities.BaseClasses;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}