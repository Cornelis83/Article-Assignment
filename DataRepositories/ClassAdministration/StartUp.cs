using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataRepositories.ClassAdministration;

public static class StartUp
{
    public static string AppSettingsFileName { get; set; } = "appsettings.json";

    public static IServiceCollection AddDataRepository(this IServiceCollection services)
        => services.AddDbContext<DataContext>(options =>
                    {
                        var connectionString = GetConnectionString();
                        options.UseSqlServer(connectionString);
                    })
                   .RegisterDependencyInjection();

    private static string GetConnectionString()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile(AppSettingsFileName, true, true);
        var configuration = configurationBuilder.Build();
        return configuration.GetConnectionString($"{nameof(DataContext)}DbConnectionString") ?? string.Empty;
    }
}