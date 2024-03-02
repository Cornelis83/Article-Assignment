namespace DataRepositories.BaseClasses;

public abstract class BaseRepository(DataContext dataContext) 
{
    protected readonly DataContext DataContext = dataContext;
}