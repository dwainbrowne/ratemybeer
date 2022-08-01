using System;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using ClassLibrary;
using ClassLibrary.Application;
using FluentValidation.Results;
using Logic;
using Logic.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Utilities;

namespace api.beer
{
    public class CreateFunction
    {
        private readonly ILogger<CreateFunction> _logger;

        public CreateFunction(ILogger<CreateFunction> log)
        {
            _logger = log;
        }


        [FunctionName("create")]
        [OpenApiOperation(operationId: "create", tags: new[] { "create" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "id", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **id** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            ApplicationResponse response = new ApplicationResponse();

            try
            {
                //Ensure the minimum required request data is valid
                bool isValidRequest = await DataValidator.IsValidId(req);


                if (isValidRequest)
                {
                    //Proceed to process full api request
                    response = await RequestProcessor.Process(req, response);

                }
              
                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                response = new ErrorResponse("Failed to process request",e);
                return new BadRequestObjectResult(response);
            }
        }

        
    }
}

