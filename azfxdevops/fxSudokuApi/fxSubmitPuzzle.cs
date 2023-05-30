using System.Net;
using Azure.Storage.Queues;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sudoku.Models.Entities;

namespace fxSudokuApi
{
    public class fxSubmitPuzzle
    {
        private readonly ILogger _logger;

        public fxSubmitPuzzle(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<fxSubmitPuzzle>();
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        [Function("fxSubmitPuzzle")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            try
            {
                _logger.LogInformation("fxSubmitPuzzle processed request");

                using var sr = new StreamReader(req.Body);
                var bodyJson = sr.ReadToEnd();
                var squares = JsonConvert.DeserializeObject<SquareDTO[]>(bodyJson);
                _logger.LogInformation($"fxSubmitPuzzle squares count = {squares.Length}");
                var puzzleDto = new PuzzleDTO() { ParentChoice = null, ParentPuzzleId = null, SubmissionDate = DateTime.UtcNow, Squares = new List<SquareDTO>(squares) };
                var puzzleDtoJson = JsonConvert.SerializeObject(puzzleDto);
                var queueClientConnectionString = Environment.GetEnvironmentVariable("cnQueuePuzzleRequests");
                var queueClient = new QueueClient(queueClientConnectionString, "puzzlerequests");
                queueClient.SendMessage(Base64Encode(puzzleDtoJson));

                var response = req.CreateResponse(HttpStatusCode.OK);
                response.WriteAsJsonAsync(puzzleDto);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
                var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                return badResponse;
            }
        }
    }
}
