using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
   

    public class APIDataStore : IDataStore
    {
        HttpClient _client = new HttpClient();
        public DataStoreLocation _dataLocation { get; set; }

        public APIDataStore()
        {
            _dataLocation = DataStoreLocation.API;
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

        public async Task<List<T>> Read<T>(DataStoreContainer container, string select = "*", string where = "")
        {
            //Convert Json back to list
            List<T> results = new List<T>();

            _client.BaseAddress = new Uri("https://api.punkapi.com/v2/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            //GET Method
            HttpResponseMessage response = await _client.GetAsync("beers?beer_name=" + where);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                results = JsonConvert.DeserializeObject<List<T>>(json);
            }


            return results;
        }

        public Task<string> Update(string id, dynamic data, DataStoreContainer container)
        {
            throw new NotImplementedException();
        }
    }
}
