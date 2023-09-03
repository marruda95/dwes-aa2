using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using bookAPI.Domain.Models;
using bookAPI.Infrastructure.Models;
using bookAPI.Infrastructure.Service;

namespace bookAPI.Domain.Controllers
{
    [Route("aa2")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [Authorize]
        [HttpGet("Employees")]
        public ActionResult<List<EmployeeInputModel>> GetEmployees(string? name, string? employeeEmail)
        {
            try
            {
                _logger.LogWarning("Method GetEmployees invoked.");

                string admin = HttpContext.User.Identity.Name;

                List<EmployeeRepository> employees = _employeeService.GetEmployees(name, employeeEmail);
                if (employees.Count > 0)
                {
                    return Ok(employees);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }
        }

    }

}

