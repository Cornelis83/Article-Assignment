using DataTransferObjects.Articles;

namespace Mappers;

[Mapper]
public static partial class ArticleMapper
{
    public static partial ArticleOverviewItemDto ToOverviewDto(Article articleOverviewItem);

    [MapProperty(nameof(Article.StockKeepingUnit), nameof(ArticleDto.SKU))]
    public static partial ArticleDto ToDto(this Article article);

    [MapProperty(nameof(ArticleDto.SKU), nameof(Article.StockKeepingUnit))]
    public static partial Article ToEntity(this ArticleDto articleDto);

    [MapProperty(nameof(ArticleCreateDto.SKU), nameof(Article.StockKeepingUnit))]
    public static partial Article ToEntity(this ArticleCreateDto articleDto);
}