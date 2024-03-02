using DataRepositories.ClassAdministration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogics.ClassAdministration;

public static class StartUp
{
    public static IServiceCollection AddBusinessLogics(this IServiceCollection services)
        => services.AddDataRepository()
                   .RegisterDependencyInjection();
}