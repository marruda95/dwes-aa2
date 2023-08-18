using bookAPI._2_Infrastructure.Database.Data;
using bookAPI._2_Infrastructure.Models;

namespace bookAPI._2_Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDataBaseService _databaseService;
        public EmployeeService(DataBaseService databaseService)
        {
           _databaseService = databaseService;
        }

        public List<EmployeeRepository> GetEmployees(string? name, string? employeeEmail)
        {
            return _databaseService.GetEmployeesDb(name, employeeEmail);
        }
    }

}