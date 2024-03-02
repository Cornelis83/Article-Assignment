using Entities.BaseClasses;

namespace BusinessLogics.BaseClasses;

public abstract class BaseLogic<TEntity, TRepository>(TRepository repository)
    where TEntity : BaseEntity, new()
{
    protected readonly TRepository Repository = repository;
}