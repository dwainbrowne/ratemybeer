using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class Factory 
    {
        public static IServiceEvaluator? CreateService(HttpRequest req)
        {
            IServiceEvaluator? _service = new RatingsService(); 

            string id = req.Query["id"];

            string datatype = "";

            switch (datatype)
            {
                case "rating":
                    _service = new RatingsService();
                    break;
            }

            return _service;
        }
    }
}
