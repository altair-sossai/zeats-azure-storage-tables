using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using Zeats.Azure.Storage.Tables.Extensions;

namespace Zeats.Azure.Storage.Tables.UnitOfWork;

public class UnitOfWorkAzureStorageTables
{
    private readonly CloudStorageAccount _storageAccount;

    public UnitOfWorkAzureStorageTables(string connectionString)
    {
        _storageAccount = CloudStorageAccount.Parse(connectionString);
    }

    public CloudTable GetTableReference(string tableName, TableClientConfiguration tableClientConfiguration = null)
    {
        return _storageAccount.GetTableReference(tableName, tableClientConfiguration);
    }

    public async Task CreateTableIfNotExistsAsync(string tableName)
    {
        await _storageAccount.CreateIfNotExistsAsync(tableName);
    }

    public async Task<TableResult> InsertOrMergeAsync(string tableName, ITableEntity entity)
    {
        return await _storageAccount.InsertOrMergeAsync(tableName, entity);
    }

    public async Task<T> RetrieveAsync<T>(string tableName, string partitionKey, string rowKey)
        where T : class, ITableEntity
    {
        return await _storageAccount.RetrieveAsync<T>(tableName, partitionKey, rowKey);
    }
}