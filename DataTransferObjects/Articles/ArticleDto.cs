namespace DataTransferObjects.Articles;

public class ArticleDto : BaseDto
{
    public string SKU { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }
}