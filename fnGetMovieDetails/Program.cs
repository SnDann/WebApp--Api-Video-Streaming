using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Cosmos;
using System;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(s =>
    {
        string connectionString = Environment.GetEnvironmentVariable("CosmosDBConnection");
        s.AddSingleton(new CosmosClient(connectionString));
    })
    .Build();

host.Run();
