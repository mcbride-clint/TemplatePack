using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CompanyApp.WebApi.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : Controller
    {
        private readonly ProblemDetailsFactory problemDetailsFactory;

        public ErrorController(ProblemDetailsFactory problemDetailsFactory)
        {
            this.problemDetailsFactory = problemDetailsFactory;
        }
        [Route("/error")]
        public IActionResult HandleError()
        {
            ProblemDetails problem = problemDetailsFactory.CreateProblemDetails(HttpContext);

            // Add Additional Problem Details if needed
            problem.Extensions.Add("bonus", "info");

            return new ObjectResult(problem);
        }
    }
}
