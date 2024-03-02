namespace DataRepositories.Interfaces;

public interface IArticleRepository
{
    public List<Article> GetOverviewItems();

    public List<Article> GetByNameOrStockKeepingUnit(string name, string stockKeepingUnit);

    public Article? GetById(int id);

    public Article Create(Article article);

    public Article Update(Article article);

    public bool Delete(Article article);
}