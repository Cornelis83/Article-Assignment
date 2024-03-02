using DataTransferObjects.Articles;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticlesController(IArticleLogic articleLogic) : BaseController<IArticleLogic>(articleLogic)
{
    [HttpGet(nameof(Get))]
    [SwaggerResponse(200, Type = typeof(List<ArticleOverviewItemDto>))]
    public IActionResult Get() => GuardedExecute(() => 
    {
        var articlesOverviewItems = Logic.GetOverviewItems();
        return articlesOverviewItems.Select(ArticleMapper.ToOverviewDto).ToList();
    });

    [HttpGet(nameof(GetById) + "/{id:int}")]
    [SwaggerResponse(200, Type = typeof(ArticleDto))]
    public IActionResult GetById(int id) => GuardedExecute(() => 
    {
        var article = Logic.GetById(id);
        return article.ToDto();
    });

    [HttpPost(nameof(Create))]
    [SwaggerResponse(200, Type = typeof(ArticleDto))]
    public IActionResult Create(ArticleCreateDto articleDto) => GuardedExecute(() => 
    {
        var article = articleDto.ToEntity();
        article = Logic.Create(article);
        return article.ToDto();
    });

    [HttpPut(nameof(Update))]
    [SwaggerResponse(200, Type = typeof(ArticleDto))]
    public IActionResult Update(ArticleDto articleDto) => GuardedExecute(() => 
    {
        var article = articleDto.ToEntity();
        article = Logic.Update(article);
        return article.ToDto();
    });

    [HttpDelete(nameof(DeleteById) + "/{id:int}")]
    public IActionResult DeleteById(int id) => GuardedExecute(() 
        => Logic.DeleteById(id));
}