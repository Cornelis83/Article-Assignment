namespace DataTransferObjects.Articles;

public class ArticleCreateDto
{
    public string Name { get; set; } = string.Empty;

    public string SKU { get; set; } = string.Empty;

    public decimal Price { get; set; }
}