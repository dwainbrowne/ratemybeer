using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using ClassLibrary.Application;
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

namespace Api.Beer
{
    public class ReadFunction
    {
        private readonly ILogger<ReadFunction> _logger;

        public ReadFunction(ILogger<ReadFunction> log)
        {
            _logger = log;
        }

        [FunctionName("read")]
        [OpenApiOperation(operationId: "read", tags: new[] { "read" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "q", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **query** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Read(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            ApplicationResponse response = new ApplicationResponse();

            try
            {
                //Ensure we have a query keyword to search by
                SearchQuery query = await DataValidator.IsValidQuery(req);

                //Proceed to process full api request
                response = await RequestProcessor.ProcessQuery(req, query, response);

                

                return new OkObjectResult(response);
            }
            catch (Exception e)
            {
                response = new ErrorResponse("Failed to process request", e);
                return new BadRequestObjectResult(response);
            }
        }
    }
}

