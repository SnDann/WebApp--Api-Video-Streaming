using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Builder;

var builder = FunctionsApplication.CreateBuilder(args);
builder.ConfigureFunctionsWebApplication();

// Application insights inst enabled by default, you can enable by default. See https://aka.ms/AA8r5r6
// builder.Services
//        .AddApplicationInsightsTelemetryWorkerService()
//        .ConfigureFunctionsApplicationInsights();

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = 100_000_000; // 100MB
});

builder.Build().Run();
