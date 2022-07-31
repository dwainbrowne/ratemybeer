using System.Dynamic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using ClassLibrary;
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
            string id = "";

            //Ensure we have a valid id
            (bool isValidId, string message) = await DataValidator.IsValidId(req);

            if (!isValidId)
                return new BadRequestObjectResult(message);
           

            //Evaluate Posted Data
            IServiceEvaluator service = Factory.CreateService(req);

            //Validate data logic
            if(service.IsValid())
            {

            }


            //Process Data
            service.StoreData();


            dynamic data = await DataExtractor.Extract<Ratings>(req.Body);

            string responseMessage = string.IsNullOrEmpty(id)
                ? "Please provide a valid id"
                : $"Hello, {id}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        
    }
}

