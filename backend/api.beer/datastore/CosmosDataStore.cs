
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public class CosmosDataStore : IDataStore
    {
        public DataStoreLocation _dataLocation { get; set; }

        public CosmosDataStore()
        {
            _dataLocation = DataStoreLocation.COSMOS;
        }

        public Task<dynamic> Create(dynamic data, DataStoreContainer container)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(string id, DataStoreContainer container)
        {
            throw new NotImplementedException();
        }

        public Task<T?> Get<T>(string id, DataStoreContainer container)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query<T>(DataStoreContainer container, Dictionary<string, string> where, string select = "*")
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Read<T>(DataStoreContainer container, string select = "*", string where = "")
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(string id, dynamic data, DataStoreContainer container)
        {
            throw new NotImplementedException();
        }
    }
}
