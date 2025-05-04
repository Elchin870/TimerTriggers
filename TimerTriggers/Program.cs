using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TimerTriggers.Services;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
var queueName = Environment.GetEnvironmentVariable("QueueName");

builder.Services.AddSingleton<IQueueService>(sp => new QueueService(connectionString, queueName));
builder.Build().Run();
