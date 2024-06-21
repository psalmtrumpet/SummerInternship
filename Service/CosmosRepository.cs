using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using SummerInternship.Repository;


namespace SummerInternship.Service
{
    public class CosmosRepository<T> : ICosmosRepository<T> where T : class
    {
        private readonly Container _container;

        public CosmosRepository(CosmosClient client, IOptions<DatabaseSettings> databaseSettings)
        {
            _container = client.GetContainer(databaseSettings.Value.DatabaseName, databaseSettings.Value.ContainerName);

        }

        public async Task<T> CreateItemAsync(T item, string partitionKey)
        {
            var eee = await _container.ReadContainerAsync();
            ItemResponse<T> response = await _container.CreateItemAsync(item, new PartitionKey(partitionKey));
            return response.Resource;
        }

        public async Task<T> GetItemAsync(string id, string partitionKey)
        {
            try
            {
                ItemResponse<T> response = await _container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetItemsAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                FeedResponse<T> response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<T> UpdateItemAsync(string id, T item, string partitionKey)
        {
            try
            {
                ItemResponse<T> response = await _container.ReplaceItemAsync(item, id, new PartitionKey(partitionKey));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task DeleteItemAsync(string id, string partitionKey)
        {
            await _container.DeleteItemAsync<T>(id, new PartitionKey(partitionKey));
        }
    }
}
