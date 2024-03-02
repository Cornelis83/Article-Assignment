using DataRepositories.Seeds;

namespace DataRepositories.DataContexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Article> Articles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ArticlesSeed.Execute(modelBuilder);
    }
}