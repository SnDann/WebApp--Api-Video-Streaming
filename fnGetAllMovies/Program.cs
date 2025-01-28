using Microsoft.Extensions.Hosting;
using Microsft.Azure.funcitons.Worker,Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Cosmos;

var builder = Host.CreateDefaultBuilder(args)

    builder.ConfigureFunctionsWebApplication();

    builder.Services.AddSingleton(s =>
    {
        string connectionString = Environment.GetEnvironmentVariable("CosmoDBConnection");
        return new CosmosClient(connectionString);
    });
builder.Build().Run();