using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CompanyApp.Console
{
    internal class Program
    { 
        static async Task Main(string[] args)
        {
            var app = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<Program>();
                })
                .Build();

            await app.Services.GetRequiredService<Program>().ExecuteAsync(args);
        }

        private readonly ILogger<Program> logger;

        /// <summary>
        /// Inject any Program Dependencies Here
        /// </summary>
        /// <param name="logger"></param>
        public Program(ILogger<Program> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Beginning of Program Logic
        /// </summary>
        /// <param name="args"></param>
        public async Task ExecuteAsync(string[] args)
        {
            await Task.Delay(2000);
            logger.LogInformation("Hello World");
        }
    }
}
