using Microsoft.Azure.Cosmos;

namespace SummerInternship
{
    public class CosmosDbContext : IDisposable
    {
        private readonly CosmosClient _cosmosClient;
        public Container MyContainer { get; private set; }

        public CosmosDbContext(IConfiguration configuration)
        {
            var cosmosDbSettings = configuration.GetSection("CosmosDbSettings");
            string account = cosmosDbSettings["Account"];
            string key = cosmosDbSettings["Key"];
            string databaseName = cosmosDbSettings["DatabaseName"];
            string containerName = cosmosDbSettings["ContainerName"];

            _cosmosClient = new CosmosClient(account, key);
            Database database = _cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName).GetAwaiter().GetResult();
            MyContainer = database.CreateContainerIfNotExistsAsync(containerName, "/partitionKey").GetAwaiter().GetResult();
        }

        public void Dispose()
        {
            _cosmosClient?.Dispose();
        }
    }
}
