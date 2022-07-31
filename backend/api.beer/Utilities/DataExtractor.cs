using Newtonsoft.Json;

namespace Utilities
{
    public static class DataExtractor
    {
        public static async Task<T?> Extract<T>(Stream body)
        {
            try
            {
                string requestBody = await new StreamReader(body).ReadToEndAsync();

                T? data = JsonConvert.DeserializeObject<T>(requestBody);

                return data ?? default(T);
            }
            catch (Exception e)
            { 
                throw new Exception("Error while trying to extract request data",e);
            }
        }
    }
}