
using bookAPI.Infrastructure.Models;

namespace bookAPI.Infrastructure.Services
{
    public interface IEmployeeService
    {
        List<EmployeeRepository> GetEmployees(string? name, string? employeeEmail);

    }

}

