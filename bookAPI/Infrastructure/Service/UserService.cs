using bookAPI.Domain.Models;
using bookAPI.Infrastructure.Data;
using bookAPI.Infrastructure.Models;
using System.Net;

namespace bookAPI.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IDataBaseService _databaseService;
        public UserService(IDataBaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public bool AddUser(UserInputModel user)
        {
            if (user == null)
            {
                return false;
            }
            else
            {
                var userRepository = new UserRepository();
                userRepository.Name = user.Name;
                userRepository.Email = user.Email;
                userRepository.Password = user.Password;
                userRepository.SignupDate = user.SignupDate;
                userRepository.HasDiscount = false;

                return _databaseService.AddUserDb(userRepository);
            }
        }

        public bool DeleteUser(int id)
        {
            if (id < 0)
            {
                return false;
            }
            else
            {
                return _databaseService.DeleteBookDb(id);

            }
        }

        public UserRepository GetSingleUser(int id)
        {
            var userDb = _databaseService.GetSingleUserDb(id);
            if (userDb.Name != null)
            {
                return userDb;
            }
            else
            {
                return new UserRepository();
            }

        }

        public List<UserRepository> GetUsers()
        {
            var usersDb = _databaseService.GetUsersDb();
            if (usersDb.Count > 0)
            {
                return usersDb;
            }
            else
            {
                return new List<UserRepository>();
            }
        }

        public bool OrderBook(int bookId, int userId)
        {
            if(bookId < 1 || userId < 1)
            {
                return false;
            }
            else
            {
                var userDb = _databaseService.GetSingleUserDb(userId);
                if (userDb.Name == null)
                {
                    return false;
                }
                else
                {
                    return _databaseService.OrderBook(bookId, userId);
                }
            }
        }

        public bool ReturnBook(int bookId, int userId)
        {
            if (bookId < 1 || userId < 1)
            {
                return false;
            }
            else
            {
                var userDb = _databaseService.GetSingleUserDb(userId);
                if (userDb.Name == null)
                {
                    return false;
                }
                else
                {
                    return _databaseService.ReturnBook(bookId, userId);
                }
            }
        }

        public bool UpdateUser(int id, UserInputModel user)
        {
            if (id < 0 || user.Name == null)
            {
                return false;
            }
            else
            {
                var userDb = new UserRepository();
                userDb.Name = user.Name;
                userDb.Email = user.Email;
                userDb.Password = user.Password;
                userDb.SignupDate = user.SignupDate;
                userDb.HasDiscount = user.hasDiscount;

                return _databaseService.UpdateUserDb(id, userDb);
            }
        }
    }
}
