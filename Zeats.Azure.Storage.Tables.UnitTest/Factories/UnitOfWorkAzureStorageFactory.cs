using Zeats.Azure.Storage.Tables.UnitOfWork;

namespace Zeats.Azure.Storage.Tables.UnitTest.Factories
{
    public static class UnitOfWorkAzureStorageFactory
    {
        public static UnitOfWorkAzureStorageTables New()
        {
            const string connectionString = "DefaultEndpointsProtocol=https;AccountName=zeatslauncherstorage;AccountKey=Rv7HvqP9C2u3RYBMw0OhLIrHQJvyz3Ae9Yuz8233geDkdtyYdGDWpM74uu6mqRfF0+h0TX5jX27l0cTn9fok+g==;EndpointSuffix=core.windows.net";

            return new UnitOfWorkAzureStorageTables(connectionString);
        }
    }
}