namespace DataRepositories;

public class ArticleRepository(DataContext dataContext) : BaseRepository(dataContext), IArticleRepository
{
    public List<Article> GetOverviewItems()
        => DataContext.Articles.Select(article => new Article
                   {
                       Id = article.Id,
                       Name = article.Name,
                       Price = article.Price,
                   })
                   .ToList();

    public List<Article> GetByNameOrStockKeepingUnit(string name, string stockKeepingUnit)
        => DataContext.Articles.Where(article => EF.Functions.Like(article.Name!, name) ||
                                     EF.Functions.Like(article.StockKeepingUnit!, stockKeepingUnit))
                   .ToList();

    public Article? GetById(int id)
        => DataContext.Articles.FirstOrDefault(article => article.Id == id);

    public Article Create(Article article)
    {
        DataContext.Articles.Add(article);
        DataContext.SaveChanges();

        return article;
    }

    public Article Update(Article article)
    {
        var existingTracked = DataContext.Articles.Local.FirstOrDefault(localArticle => localArticle.Id == article.Id);

        //We don't know who the caller is of this method. Therefor, it cannot be asured that the tracked article
        //is the same as the article in the parameter. Simply save the tracked article could result in changes
        //not being saved. So to be save, the tracked entity is detached in order to be able to update the article
        //in the parameter to the database. No detatching results in a run time error saying an article with 
        //the given Id is already tracked.
        if (existingTracked is not null)
        {
            DataContext.Attach(existingTracked).State = EntityState.Detached;
        }

        DataContext.Update(article);
        DataContext.SaveChanges();

        return article;
    }

    public bool Delete(Article article)
    {
        DataContext.Attach(article).State = EntityState.Unchanged;
        DataContext.Articles.Remove(article);
        var rowsChangedCount = DataContext.SaveChanges();

        return rowsChangedCount > 0;
    }
}