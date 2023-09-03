
using bookAPI.Infrastructure.Models;

namespace bookAPI.Infrastructure.Service
{
    public interface IEmployeeService
    {
        public List<EmployeeRepository> GetEmployees(string? name, string? employeeEmail);

    }
}

