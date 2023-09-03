using bookAPI.Infrastructure.Models;

namespace bookAPI.Infrastructure.Data
{
    public interface IDataBaseService
    {
        //Employee
        List<EmployeeRepository> GetEmployeesDb(string? name, string? employeeEmail);

        //User
        List<UserRepository> GetUsersDb();
        bool AddUserDb(UserRepository user);
        UserRepository GetSingleUserDb(int id);
        bool UpdateUserDb(int id, UserRepository user);
        bool DeleteUserDb(int id);

        bool OrderBook(int bookId, int userId);
        bool ReturnBook(int bookId, int userId);
        

        //Book
        bool AddBookDb(BookRepository book);
        List<BookRepository> GetBooksUserDb(int userId);        
        bool DeleteBookDb(int idBook);
        bool UpdateBookDb(int bookId, BookRepository book);
        List<BookRepository> GetAllBooksDb();

    }
}
