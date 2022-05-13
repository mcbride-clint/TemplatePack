using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// Console App Container Setup
var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((hostContext, services) =>
{
    // Add any required services
    services.AddSingleton<HostConsoleApp>();
});

var app = builder.Build();

// Create Instance of HostConsoleAppAsync and run it
await app.Services.GetRequiredService<HostConsoleAppAsync>().Main(args);

// Actual Console Logic
// Can be moved to separate file
public class HostConsoleAppAsync
{
    private readonly ILogger<HostConsoleAppAsync> _logger;

    public HostConsoleApp(ILogger<HostConsoleAppAsync> logger)
    {
        _logger = logger;
    }
    
    public async Task Main(string[] args)
    {
        _logger.LogInformation("Hello World!");
    }    
}
