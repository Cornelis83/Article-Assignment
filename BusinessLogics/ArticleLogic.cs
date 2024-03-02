namespace BusinessLogics;

public class ArticleLogic(IArticleRepository articleRepository) : BaseLogic<Article, IArticleRepository>(articleRepository), IArticleLogic
{
    public List<Article> GetOverviewItems()
        =>  Repository.GetOverviewItems();
        
    public Article GetById(int id)
    {
        var article = Repository.GetById(id);

        if (article is null)
        {
            throw new ExceptionWithMessages([ $"No article found with id: {id}" ]);
        }

        return article;
    }

    public Article Create(Article article)
    {
        var messages = Validate(article);

        if (messages is not null && messages.Any())
        {
            throw new ExceptionWithMessages(messages);
        }

        messages = CheckDuplicate(article);

        if (messages is not null && messages.Any())
        {
            throw new ExceptionWithMessages(messages);
        }

        return Repository.Create(article);
    }

    public Article Update(Article article)
    {
        var messages = Validate(article);

        if (messages is not null && messages.Any())
        {
            throw new ExceptionWithMessages(messages);
        }

        var existingArticle = Repository.GetById(article.Id);
        
        if (existingArticle is null)
        {
            throw new ExceptionWithMessages([ $"No article found with Id {article.Id}. Cannot update an non-existing article." ]);
        }

        if (article.Name != existingArticle.Name ||
            article.StockKeepingUnit != existingArticle.StockKeepingUnit)
        {
            messages = CheckDuplicate(article);

            if (messages is not null && messages.Any())
            {
                throw new ExceptionWithMessages(messages);
            }
        }

        return Repository.Update(article);
    }

    public bool DeleteById(int id)
    {
        var article = Repository.GetById(id);

        if (article is null)
        {
            //The article does not exist (anymore) so the goal of execution is achieved.
            return true;
        }

        return Repository.Delete(article);
    }

    private IEnumerable<string> Validate(Article article)
    {
        if (string.IsNullOrWhiteSpace(article.Name))
        {
           yield return "Name is required.";
        }

        if (string.IsNullOrWhiteSpace(article.StockKeepingUnit))
        {
            yield return "SKU is required.";
        }

        if (article.Price <= 0) //Free does not exist. If it does (change of use-case), simply remove the = 
        {
            yield return "Invalid price. Price must be higher than 0.";
        }
    }

    private IEnumerable<string> CheckDuplicate(Article article)
    {
        var duplicates = Repository.GetByNameOrStockKeepingUnit(article.Name!, article.StockKeepingUnit!)
                                   .Where(duplicate => duplicate.Id != article.Id)
                                   .ToList();

        var duplicateName = duplicates
            .FirstOrDefault(duplicate => duplicate.Name.Equals(article.Name, StringComparison.InvariantCultureIgnoreCase));

        if (duplicateName is not null)
        {
            yield return $"Article name '{article.Name}' must be unique but is already in use for article with " +
                            $"SKU '{duplicateName.StockKeepingUnit}' (article Id: {duplicateName.Id}).";
        }

        var duplicateStockKeepingUnit = duplicates
            .FirstOrDefault(duplicate => duplicate.StockKeepingUnit.Equals(article.StockKeepingUnit, StringComparison.InvariantCultureIgnoreCase));

        if (duplicateStockKeepingUnit is not null)
        {
            yield return $"Article SKU '{article.StockKeepingUnit}' must be unique but is already in use for article with " +
                            $"Name '{duplicateStockKeepingUnit.Name}' (article Id: {duplicateStockKeepingUnit.Id})";
        } 
    }
}