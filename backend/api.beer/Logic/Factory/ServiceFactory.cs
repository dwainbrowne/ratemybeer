using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Logic
{
    public static class Factory 
    {
       

        public static async Task<IService?> CreateService(HttpRequest req)
        {
            //Get request query string and body data
            IQueryCollection query = req.Query;
            string body = body = await DataExtractor.GetBody(req.Body);

            IService? _service = null;


            string datatype = "";

            //Dynamically determine which business logic service to call
            switch (datatype)
            {
                case "rating":
                    _service = new RatingsService(query, body);
                    break;
            }

            return _service;
        }
    }
}
