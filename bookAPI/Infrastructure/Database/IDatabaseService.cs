using bookAPI.Infrastructure.Models;

namespace bookAPI.Infrastructure.Database.Data
{
    public interface IDataBaseService
    {
        //Employee
        List<EmployeeRepository> GetEmployeesDb(string? name, string? employeeEmail);

        //User
        List<UserRepository> GetUsersDb();
        bool AddUserDb(UserRepository user);
        UserRepository GetSingleUserDb(int id);
        UserRepository UpdateUserDb(int id, UserRepository user);
        bool DeleteUserDb(int id);
        bool OrderBook(int bookId, int userId);
        bool ReturnBook(int bookId, int userId);
        

        //Book
        bool AddBookDb(int employeeId, BookRepository book);
        List<BookRepository> GetBooksUserDb(int employeeId, int userId);        
        bool DeleteBookDb(int employeeId, int idBook);
        BookRepository UpdateBookDb(int employeeId, int bookId, BookRepository book);
        List<BookRepository> GetAllBooksDb();

    }
}
