namespace BusinessLogics.Interfaces;

public interface IArticleLogic
{
    public List<Article> GetOverviewItems();

    public Article GetById(int id);

    public Article Create(Article article);

    public Article Update(Article article);

    public bool DeleteById(int id);
}