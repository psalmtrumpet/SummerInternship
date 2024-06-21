namespace SummerInternship.Repository
{
    public interface ICosmosRepository<T> where T : class
    {
        Task<T> CreateItemAsync(T item, string partitionKey);
        Task<T> GetItemAsync(string id, string partitionKey);
        Task<IEnumerable<T>> GetItemsAsync(string queryString);
        Task<T> UpdateItemAsync(string id, T item, string partitionKey);
        Task DeleteItemAsync(string id, string partitionKey);
    }
}
