using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace fx1
{
    public class fxSayHello
    {
        private readonly ILogger _logger;

        public fxSayHello(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<fxSayHello>();
        }

        [Function("fxSayHello")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var myFunctionSetting1 = Environment.GetEnvironmentVariable("MY_FUNCTION_SETTING1");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!\n");
            response.WriteString($"MY_FUNCTION_SETTING1 - [{myFunctionSetting1}]\n");

            return response;
        }
    }
}
