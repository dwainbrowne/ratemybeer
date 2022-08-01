using ClassLibrary.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// RequestProcessor is responsible for standardizing the steps involved when processing a request.
    /// </summary>
    public static class RequestProcessor
    {
        /// <summary>
        /// Handle all create, update request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<ApplicationResponse> Process(HttpRequest request, ApplicationResponse response)
        {
            try
            {  
                //Evaluate the request and dynamically create service object to handle custom business logic
                IService? service = await Factory.CreateService(request);


                if (service == null)
                    throw new Exception("Failed to initialize factory service");


                //Extract data for further processing
                service.SetDataProperties();


                //Only proceed to process request if custom business logic is valid
                if (service.IsValid())
                {
                    //Store aplication request data
                    response = await service.StoreData();

                    response.Success = true;
                }
                else
                    throw new Exception("Data validation failed");


                return response;
            }
            catch (Exception e)
            {
                throw new Exception($"Error while processing application request: {e.Message}");
            }
        }

        /// <summary>
        /// Handles all search query request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<ApplicationResponse> ProcessQuery(HttpRequest request, SearchQuery query, ApplicationResponse response)
        {
            try
            {
                //Evaluate the request and dynamically create service object to handle custom business logic
                IService? service = await Factory.CreateService(request);


                if (service == null)
                    throw new Exception("Failed to initialize factory service");


                //Store aplication request data
                response = await service.GetData(query);


                response.Success = true;      

                return response;
            }
            catch (Exception e)
            {
                throw new Exception($"Error while processing application request: {e.Message}");
            }
        }
    }
}
