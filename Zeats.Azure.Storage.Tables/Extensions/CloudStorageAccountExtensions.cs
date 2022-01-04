using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace Zeats.Azure.Storage.Tables.Extensions
{
    public static class CloudStorageAccountExtensions
    {
        public static CloudTable GetTableReference(this CloudStorageAccount storageAccount, string tableName, TableClientConfiguration tableClientConfiguration = null)
        {
            tableClientConfiguration ??= new TableClientConfiguration();

            var tableClient = storageAccount.CreateCloudTableClient(tableClientConfiguration);

            return tableClient.GetTableReference(tableName);
        }

        public static async Task CreateIfNotExistsAsync(this CloudStorageAccount storageAccount, string tableName)
        {
            var table = storageAccount.GetTableReference(tableName);

            await table.CreateIfNotExistsAsync();
        }

        public static async Task<TableResult> InsertOrMergeAsync(this CloudStorageAccount storageAccount, string tableName, ITableEntity entity)
        {
            var table = storageAccount.GetTableReference(tableName);

            var operation = TableOperation.InsertOrMerge(entity);

            return await table.ExecuteAsync(operation);
        }

        public static async Task<T> RetrieveAsync<T>(this CloudStorageAccount storageAccount, string tableName, string partitionKey, string rowKey)
            where T : class, ITableEntity
        {
            var table = storageAccount.GetTableReference(tableName);

            var operation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            var result = await table.ExecuteAsync(operation);
            var entity = result.Result as T;

            return entity;
        }
    }
}