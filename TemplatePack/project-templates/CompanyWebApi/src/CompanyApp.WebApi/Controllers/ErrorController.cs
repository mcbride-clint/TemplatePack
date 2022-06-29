using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CompanyApp.WebApi.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        private readonly ProblemDetailsFactory problemDetailsFactory;

        public ErrorController(ProblemDetailsFactory problemDetailsFactory)
        {
            this.problemDetailsFactory = problemDetailsFactory;
        }
        [Route("")]
        public IActionResult HandleError()
        {
            ProblemDetails problem = problemDetailsFactory.CreateProblemDetails(HttpContext);

            // Add Additional Problem Details to be returned, if needed
            problem.Extensions.Add("bonus", "info");

            return new ObjectResult(problem);
        }
    }
}
