using System.Dynamic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using ClassLibrary;
using ClassLibrary.Validator;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

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
            dynamic data = new ExpandoObject();
            string id = req.Query["id"];

            data = await ExtractData(req);

            string responseMessage = string.IsNullOrEmpty(id)
                ? "Please provide a valid id"
                : $"Hello, {id}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        private static async Task<dynamic> ExtractData(HttpRequest req)
        {            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Ratings data = JsonConvert.DeserializeObject<Ratings>(requestBody);

            ValidationResult ratingValidationResult = new RatingsValidator().Validate(data);
            

            return data;
        }
    }
}

