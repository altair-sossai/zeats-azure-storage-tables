using Microsoft.Extensions.DependencyInjection;

namespace Zeats.Azure.Storage.Tables.UnitOfWork;

public static class UnitOfWorkAzureStorageTablesDependencyInjection
{
    public static IServiceCollection AddUnitOfWorkAzureStorageTables(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection
            .AddScoped(s => new UnitOfWorkAzureStorageTables(connectionString));

        return serviceCollection;
    }
}