namespace Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfractructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        return services;
    }
}
