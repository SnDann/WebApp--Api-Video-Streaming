using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;

namespace fnGetAllMovie
{
    
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly CosmosClient _cosmosClient;

        public Function1(ILogger<Function1> logger, CosmosClient cosmosClient)
        {
            _logger = logger;
            _cosmosClient = cosmosClient;
        }

        [Function("all")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var container = _cosmosClient.GetContainer("ToDoListDB", "movies");
            var id = req.Query["id"];
            var query = "SELECT * FROM c";
            var queryDefinition = new QueryDefinition(query);
            var result = container.GetItemQueryIterator<MovieResult>(queryDefinition);
            var results = new List<MovieResult>();

            while(result.HasMoreResults)
            {
                foreach (var item int await result.ReadNextAsync())
                {

                     results.Add(item);
               
                }
            }

            var responseMessage = req.CreateResponse(System.Net.HttStatusCode.OK);
            await responseMessage.writeAsJsonAsync(results);

            return ResponseMessage;
        }
    }
   }
