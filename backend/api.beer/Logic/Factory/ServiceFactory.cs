using ClassLibrary.Application;
using ClassLibrary.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Logic
{

    /// <summary>
    /// Factory class is responsible for evaluating the request and deciding which instance of the service object to instantiate
    /// </summary>
    public static class Factory 
    {
       

        public static async Task<IService?> CreateService(HttpRequest req)
        {
            IService? _service = null;
            EntityType entityType;

            //Get request query string and body data
            IQueryCollection query = req.Query;
            string body = body = await DataExtractor.GetBody(req.Body);

            //Evaluate the request and get the data type
            ApplicationRequest? request = DataExtractor.Extract<ApplicationRequest>(body);


            Enum.TryParse<EntityType>(request?.Type, ignoreCase:true, out entityType);


            //Dynamically determine which business logic service to call
            _service = DynamicallyCreateServiceObject(_service, entityType, query, body);

            return _service;
        }




        private static IService? DynamicallyCreateServiceObject(IService? _service, EntityType entityType, IQueryCollection query, string body)
        {
            switch (entityType)
            {
                case EntityType.Beer:
                    _service = new BeerService(query, body);
                    break;
                case EntityType.Ratings:
                    _service = new RatingsService(query, body);
                    break;
            }

            return _service;
        }
    }
}
