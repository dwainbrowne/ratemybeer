using Newtonsoft.Json;

namespace Utilities
{
    public static class DataExtractor
    {

        /// <summary>
        /// Takes the request body as a stream and returns the string equivalent
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static async Task<string> GetBody(Stream body)
        {
            string requestBody = await new StreamReader(body).ReadToEndAsync();

            return requestBody;
        }


        /// <summary>
        /// Takes the request body as a string and returns a concrete object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static T? Extract<T>(string requestBody)
        {
            try
            {   
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