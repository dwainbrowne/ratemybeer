using ClassLibrary;
using Logic.Service;
using Microsoft.AspNetCore.Http;
using System.Dynamic;
using Utilities;

namespace Logic
{
    public class RatingsService : AbstractService, IService
    {
        Ratings? _ratings;

        public RatingsService(IQueryCollection query, string body):base(query, body)
        {

        }
        

        private async Task<dynamic?> Extractor(HttpRequest req)
        {
            dynamic? data = new ExpandoObject();

             data = await DataExtractor.Extract<Ratings>(_body);

            return data;
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public bool StoreData()
        {
            throw new NotImplementedException();
        }
    }
}