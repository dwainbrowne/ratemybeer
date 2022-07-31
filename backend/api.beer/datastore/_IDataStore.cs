using DataStore;

namespace datastore
{
    public interface IDataStore
    {
        Task<bool> Create(dynamic data, DataStoreContainer container);

        Task<T?> Get<T>(string id, DataStoreContainer container);

        Task<List<T>> Read<T>(DataStoreContainer container, string select = "*", string where = "");

        Task<List<T>> Query<T>(DataStoreContainer container, Dictionary<string, string> where, string select = "*");

        Task<string> Update(string id, dynamic data, DataStoreContainer container);

        Task<string> Delete(string id, DataStoreContainer container);

    }
}