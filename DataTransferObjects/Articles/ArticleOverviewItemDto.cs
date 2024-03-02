namespace DataTransferObjects.Articles;

public class ArticleOverviewItemDto : BaseDto
{
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }
}