using bookAPI.Domain.Models;

namespace bookAPI.Infrastructure.Contracts
{
    public interface IEmployeeRepository
    {
        List<EmployeeInputModel> GetEmployees(string? name, string? speciality, string? order);
        bool AddEmployeeDb(EmployeeInputModel employee);
        EmployeeInputModel GetSingleEmployee(int id);
        bool DeleteEmployee(int id);
        EmployeeInputModel UpdateEmployee(int id, EmployeeInputModel employee);

        //Appintments
        List<BookInputModel> GetBooksRepository(int id);

        bool DeleteBook(int idEmployee, int idBook);

        BookInputModel UpdateBook(int idEmployee, int idBook, BookInputModel bookRepository);

    }
}
