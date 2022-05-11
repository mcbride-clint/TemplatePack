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

// Create Instance of HostConsoleApp and run it
app.Services.GetRequiredService<HostConsoleApp>().Main(args);

// Actual Console Logic
// Can be moved to seperate file
public class HostConsoleApp
{
    private readonly ILogger<HostConsoleApp> _logger;

    public HostConsoleApp(ILogger<HostConsoleApp> logger)
    {
        _logger = logger;
    }

    public void Main(string[] args)
    {
        _logger.LogInformation("Hello World!");
    }    
}
