using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CompanyApp.Console
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            var app = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<Program>();
                })
                .Build();

            app.Services.GetRequiredService<Program>().Execute(args);
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
        public void Execute(string[] args)
        {
            logger.LogInformation("Hello World");
        }
    }
}
