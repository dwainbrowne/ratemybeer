
namespace DataStore
{
    public interface IDataStore
    {
        //Determins where the data should be stored, use to enforce implementation
        public DataStoreLocation _dataLocation { get; set; }
         

        Task<dynamic> Create(dynamic data, DataStoreContainer container);

        Task<T?> Get<T>(string id, DataStoreContainer container);

        Task<List<T>> Read<T>(DataStoreContainer container, string select = "*", string where = "");

        Task<List<T>> Query<T>(DataStoreContainer container, Dictionary<string, string> where, string select = "*");

        Task<string> Update(string id, dynamic data, DataStoreContainer container);

        Task<string> Delete(string id, DataStoreContainer container);

    }
}