using bookAPI.Domain.Models;
using bookAPI.Infrastructure.Data;
using bookAPI.Infrastructure.Database;
using bookAPI.Infrastructure.Models;

namespace bookAPI.Infrastructure.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDataBaseService _databaseService;
        public EmployeeService(IDataBaseService databaseService)
        {
           _databaseService = databaseService;
        }

        public List<EmployeeRepository> GetEmployees(string? name, string? employeeEmail)
        {
            return _databaseService.GetEmployeesDb(name, employeeEmail);
        }
    }

}