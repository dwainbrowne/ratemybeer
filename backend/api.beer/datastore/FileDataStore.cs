
using ClassLibrary.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public class FileDataStore : IDataStore
    {
        public DataStoreLocation _dataLocation { get; set; }
        private string? _filePath = "";

        public FileDataStore()
        {
            _dataLocation = DataStoreLocation.FILE;

            _filePath = AppSettings.FILE_PATH;
        }

        public async Task<dynamic> Create(dynamic data, DataStoreContainer container)
        {
           
            dynamic response = new ExpandoObject();

            try
            {
                await File.WriteAllTextAsync(_filePath, data);

                response = data;

                return response;
            }
            catch (Exception e)
            {
                throw new Exception($"Error while saving file {_filePath}",e);
            }
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

            try
            {

                // Read existing json data
                string? json = await File.ReadAllTextAsync(_filePath);


                //Convert Json back to list
                List<T> results = JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();

                return results;
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to ready file from disk {_filePath} : {e.Message}");
            }
        }

        public Task<string> Update(string id, dynamic data, DataStoreContainer container)
        {
            throw new NotImplementedException();
        }
    }
}
