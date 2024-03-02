using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogics.ClassAdministration;

internal static class DependencyInjectionRegistration
{
    internal static IServiceCollection RegisterDependencyInjection(this IServiceCollection services)
        => services.AddScoped<IArticleLogic, ArticleLogic>();                 
}