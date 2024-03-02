using Microsoft.Extensions.DependencyInjection;

namespace DataRepositories.ClassAdministration;

internal static class DepedencyInjectionRegistration
{
    internal static IServiceCollection RegisterDependencyInjection(this IServiceCollection services)
        => services.AddScoped<IArticleRepository, ArticleRepository>();
}