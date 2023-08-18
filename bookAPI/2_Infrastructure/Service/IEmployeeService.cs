
using bookAPI._2_Infrastructure.Models;

namespace bookAPI._2_Infrastructure.Services
{
    public interface IEmployeeService
    {
        List<EmployeeRepository> GetEmployees(string? name, string? employeeEmail);

    }

}

