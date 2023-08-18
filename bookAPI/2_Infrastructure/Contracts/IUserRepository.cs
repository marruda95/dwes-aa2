using bookAPI._1_Domain.Models;
using bookAPI._2_Infrastructure.Models;

namespace bookAPI._2_Infrastructure.Contracts
{
    public interface IUserInputModel
    {
        List<UserRepository> GetEmployees();
        bool AddEmployee(UserRepository user);
        UserRepository GetSingleEmployee(int id);
        bool DeleteEmployee(int id);
        UserRepository UpdateEmployee(int id, UserRepository user);

        //Book
        bool AddBook(int id, string specility);
        List<BookInputModel> GetBooksRepository(int id);
        BookInputModel GetBookRepository(int idEmployee, int idBook);
    }
}
