using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using bookAPI.Domain.Models;
using bookAPI.Infrastructure.Services;
using bookAPI.Infrastructure.Models;

namespace bookAPI.Domain.Controllers
{

    //add-migration migration1
    //update-database

    //USE master;
    //ALTER DATABASE[aa2PRE] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    //DROP DATABASE[aa2PRE];

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

        [HttpGet("Employees")]
        public ActionResult<List<EmployeeInputModel>> GetEmployees(string? name, string? employeeEmail)
        {
            try
            {
                _logger.LogWarning("Method GetEmployees invoked.");
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

    //     [Authorize] // admin and employee  => Basic ZGVtbzFAZGVtby5jb206ZGVtbzE=   email:password
    //     [HttpGet("Employee/{id}")]
    //     public ActionResult<EmployeeInputModel> GetEmployee(int id)
    //     {
    //         try
    //         {
    //             _logger.LogWarning("Method Employee invoked.");

    //             string employeedValidated = HttpContext.User.Identity.Name;
    //             int intEmployeeValidated = 0;
    //             if (employeedValidated != "admin")
    //             {
    //                 intEmployeeValidated = Int32.Parse(employeedValidated);
    //             }

    //             if (id == intEmployeeValidated || employeedValidated == "admin")
    //             {
    //                 EmployeeInputModel employeeDto = _employeeService.GetEmployeeInputModel(id);
    //                 if (employeeDto == null || employeeDto.Name == null)
    //                 {
    //                     return NotFound();
    //                 }
    //                 else
    //                 {
    //                     return Ok(employeeDto);
    //                 }
    //             }
    //             else
    //             {
    //                 return BadRequest("Error");
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             _logger.LogWarning(ex.Message);
    //             return BadRequest();
    //         }
    //     }

    //     [HttpPost("/Employee/AUTH/REGISTER")]
    //     public ActionResult AddEmployee(EmployeeInputModel employeeInput)
    //     {
    //         try
    //         {
    //             _logger.LogWarning($"Method AddEmployee invoked.");

    //            // var employeeDto = _employeeInputToDto.mapEmployeeInputToDto(employeeInput);
    //             bool EmployeeStatus = _employeeService.AddEmployeeInputModel(employeeInput);
    //             if (EmployeeStatus)
    //             {
    //                 return Ok("Employee added");
    //             }
    //             else
    //             {
    //                 return BadRequest("Error");
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             _logger.LogWarning(ex.Message);
    //             return BadRequest();
    //         }
    //     }

    //     [Authorize] // admin and employee
    //     [HttpDelete("Employee/{id}")]
    //     public ActionResult DeleteEmployee(int id)
    //     {
    //         try
    //         {
    //             _logger.LogWarning($"Method deleteEmployee invoked.");

    //             string employeedValidated = HttpContext.User.Identity.Name;
    //             int intEmployeeValidated = 0;
    //             if (employeedValidated != "admin")
    //             {
    //                 intEmployeeValidated = Int32.Parse(employeedValidated);
    //             }

    //             if (id == intEmployeeValidated || employeedValidated == "admin")
    //             {
    //                 var deletedEmployee = _employeeService.DeleteEmployeeInputModel(id);
    //                 if (deletedEmployee)
    //                 {
    //                     return Ok("Employee removed");
    //                 }
    //                 else
    //                 {
    //                     return NotFound("This Employee does not exist");
    //                 }
    //             } else
    //             {
    //                 return BadRequest("Error");
    //             } 
    //         }
    //         catch (Exception ex)
    //         {
    //             _logger.LogWarning(ex.Message);
    //             return BadRequest();
    //         }
    //     }

    //     [Authorize] // employee
    //     [HttpPut("Employee/{id}")]
    //     public ActionResult UpdateEmployee(int id, EmployeeInputModel employeeInput) 
    //     {
    //         try
    //         {
    //             _logger.LogWarning("Method UpdateEmployee invoked.");

    //             string employeeIdValidated = HttpContext.User.Identity.Name;
    //             if (id == Int32.Parse(employeeIdValidated))
    //             {
    //                 //var employeeDto = _employeeInputToDto.mapEmployeeInputToDto(employeeInput);

    //                 var specilaistUpdatedto = _employeeService.UpdateEmployeeInputModel(id, employeeInput);
    //                 if (specilaistUpdatedto.Id >= 1)
    //                 {
    //                     return Ok("Employee updated.");

    //                 }
    //                 else
    //                 {
    //                     return BadRequest("Error");
    //                 }
    //             } else 
    //             {
    //                 return BadRequest("Error");
    //             }
    //         } 
    //         catch(Exception ex)
    //         {
    //             _logger.LogWarning(ex.Message);
    //             return BadRequest();
    //         }   
    //     }

    //     //Books
    //     [Authorize] //admin and employee
    //     [HttpGet("Employee/{id}/Books")]
    //     public ActionResult<List<BookInputModel>> GetBooks(int id)
    //     {
    //         try
    //         {
    //             _logger.LogWarning("Method GetBooks invoked.");

    //             string patientIdValidated = HttpContext.User.Identity.Name;
    //             int intUserIdValidated = 0;
    //             if (patientIdValidated != "admin")
    //             {
    //                 intUserIdValidated = Int32.Parse(patientIdValidated);
    //             }

    //             if (id == intUserIdValidated || patientIdValidated == "admin")
    //             {
    //                 List<BookInputModel> books = _employeeService.GetBooksDto(id);
    //                 if (books.Count > 0)
    //                 {
    //                     return Ok(books);
    //                 }
    //                 else
    //                 {
    //                     return NotFound();
    //                 }
    //             }
    //             else
    //             {
    //                 return BadRequest("Error");
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             _logger.LogWarning(ex.Message);
    //             return BadRequest();
    //         }
    //     }

    //     [Authorize] // admin and employee
    //     [HttpDelete("Employee/{idEmployee}/Book/{idBook}")]
    //     public ActionResult DeleteBook(int idEmployee, int idBook)
    //     {
    //         try
    //         {
    //             _logger.LogWarning($"Method DeleteBook invoked.");

    //             string employeedValidated = HttpContext.User.Identity.Name;
    //             int intEmployeeValidated = 0;
    //             if (employeedValidated != "admin")
    //             {
    //                 intEmployeeValidated = Int32.Parse(employeedValidated);
    //             }

    //             if (idEmployee == intEmployeeValidated || employeedValidated == "admin")
    //             {
    //                 var deletedAppoinment = _employeeService.DeleteBook(idEmployee, idBook);
    //                 if (deletedAppoinment)
    //                 {
    //                     return Ok("Appoinment removed");
    //                 }
    //                 else
    //                 {
    //                     return NotFound("This Appoinment does not exist");
    //                 }
    //             }
    //             else
    //             {
    //                 return BadRequest("Error");
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             _logger.LogWarning(ex.Message);
    //             return BadRequest();
    //         }
    //     }

    //     [Authorize] // employee
    //     [HttpPut("Employee/{idEmployee}/Book/{idBook}")]
    //     public ActionResult UpdateBook(int idEmployee, int idBook, BookInputModel employeeInput)
    //     {
    //         try
    //         {
    //             _logger.LogWarning("Method UpdateBook invoked.");

    //             string employeeIdValidated = HttpContext.User.Identity.Name;
    //             if (idEmployee == Int32.Parse(employeeIdValidated))
    //             {
    //                // var bookDTO = _employeeInputToDto.mapBookInputToDto(employeeInput);
    //                 var bookUpdateDto = _employeeService.UpdateBookInputModel(idEmployee, idBook, employeeInput);

                    
    //                 if (bookUpdateDto.Id > 1)
    //                 {
    //                     return Ok("Book updated.");

    //                 }
    //                 else
    //                 {
    //                     return BadRequest("Error");
    //                 }
    //             }
    //             else
    //             {
    //                 return BadRequest("Error");
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             _logger.LogWarning(ex.Message);
    //             return BadRequest();
    //         }
    //     }
    // }

}

}

