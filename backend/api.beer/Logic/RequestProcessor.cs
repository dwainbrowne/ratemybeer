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
    public static class RequestProcessor
    {
        public static async Task<ApplicationResponse> Process(HttpRequest request, ApplicationResponse response)
        {
            try
            {  
                //Evaluate the request and dynamically create service object to handle custom business logic
                IService? service = await Factory.CreateService(request);


                if (service == null)
                    throw new Exception("Failed to initialize factory service");


                //Only proceed to process request if custom business logic is valid
                if (service.IsValid())
                {


                    //Store aplication request data
                    service.StoreData();

                    response.Success = true;
                }
                
                return response;
            }
            catch (Exception e)
            {
                throw new Exception($"Error while processing application request: {e.Message}");
            }
        }
    }
}
