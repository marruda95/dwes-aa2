
using bookAPI.Domain.Models;
using bookAPI.Infrastructure.Models;

namespace bookAPI.Infrastructure.Service
{
    public interface IUserService
    {
        List<UserRepository> GetUsers();
        bool AddUser(UserInputModel user);
        UserRepository GetSingleUser(int id);
        bool UpdateUser(int id, UserInputModel user);
        bool DeleteUser(int id);

        bool OrderBook(int bookId, int userId);
        bool ReturnBook(int bookId, int userId);
    }
}