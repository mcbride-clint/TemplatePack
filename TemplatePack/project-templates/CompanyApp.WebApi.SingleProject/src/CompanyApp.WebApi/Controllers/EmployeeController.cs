using CompanyApp.Application.Services.Employees;
using CompanyApp.Application.Services.Employees.Models;
using CompanyApp.Application.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly EmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, EmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet("", Name = "GetEmployees")]
        [HttpGet("search", Name = "GetEmployeesAlt")]
        public ActionResult<IEnumerable<Employee>> Query([FromQuery] EmployeeFilter? filter)
        {
            return Ok(_employeeService.GetEmployees(filter));
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = _employeeService.GetEmployees(new EmployeeFilter() { Id = id }).SingleOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost("", Name = "CreateEmployee")]
        public ActionResult<Employee> Create(CreateEmployeeRequest request)
        {
            var newEmployee = _employeeService.CreateEmployee(request);
            return CreatedAtRoute("GetEmployee", new { id = newEmployee.Id }, newEmployee);
        }

        [HttpPut("{id}", Name = "UpdateEmployee")]
        public ActionResult<Employee> Update([FromRoute] int id, UpdateEmployeeRequest request)
        {
            var existingEmployee = _employeeService.GetEmployees(new EmployeeFilter() { Id = id }).SingleOrDefault();
            if (existingEmployee == null)
            {
                return NotFound();
            }

            var employee = _employeeService.UpdateEmployee(id, request);
            return Ok(employee);
        }
    }
}
