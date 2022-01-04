using Microsoft.Extensions.Configuration;
using Zeats.Azure.Storage.Tables.UnitOfWork;

namespace Zeats.Azure.Storage.Tables.UnitTest.Factories;

public static class UnitOfWorkAzureStorageFactory
{
    public static UnitOfWorkAzureStorageTables New()
    {
        var configuration = ConfigurationFactory.New();
        var connectionString = configuration.GetValue<string>("AzureWebJobsStorage");

        return new UnitOfWorkAzureStorageTables(connectionString);
    }
}