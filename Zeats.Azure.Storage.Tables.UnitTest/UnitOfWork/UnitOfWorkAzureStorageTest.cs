using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zeats.Azure.Storage.Tables.UnitOfWork;
using Zeats.Azure.Storage.Tables.UnitTest.Factories;

namespace Zeats.Azure.Storage.Tables.UnitTest.UnitOfWork
{
    [TestClass]
    public class UnitOfWorkAzureStorageTest
    {
        private const string TableName = "UnitTestTable";
        private UnitOfWorkAzureStorageTables _unitOfWorkAzureStorageTables;

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWorkAzureStorageTables = UnitOfWorkAzureStorageFactory.New();
        }

        [TestMethod]
        public void GetTableReference()
        {
            var tableReference = _unitOfWorkAzureStorageTables.GetTableReference(TableName);

            Assert.IsNotNull(tableReference);
        }

        [TestMethod]
        public async Task CreateTableIfNotExistsAsync()
        {
            await _unitOfWorkAzureStorageTables.CreateTableIfNotExistsAsync(TableName);

            var tableReference = _unitOfWorkAzureStorageTables.GetTableReference(TableName);
            var exists = await tableReference.ExistsAsync();

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public async Task InsertOrMergeAsync()
        {
            var sampleEntity = new SampleEntity
            {
                PartitionKey = "shared",
                RowKey = "1",
                Name = "Lorem Ipsum"
            };

            var tableResult = await _unitOfWorkAzureStorageTables.InsertOrMergeAsync(TableName, sampleEntity);
            var result = tableResult.Result as SampleEntity;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task RetrieveAsync()
        {
            var sampleEntity = new SampleEntity
            {
                PartitionKey = "shared",
                RowKey = "2",
                Name = "Lorem Ipsum"
            };

            await _unitOfWorkAzureStorageTables.InsertOrMergeAsync(TableName, sampleEntity);

            sampleEntity = await _unitOfWorkAzureStorageTables.RetrieveAsync<SampleEntity>(TableName, sampleEntity.PartitionKey, sampleEntity.RowKey);

            Assert.IsNotNull(sampleEntity);
        }

        private class SampleEntity : TableEntity
        {
            public string Name { get; set; }
        }
    }
}