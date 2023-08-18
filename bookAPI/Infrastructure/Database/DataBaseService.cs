using bookAPI.Infrastructure.Models;
using bookAPI.Infrastructre.Context;
using bookAPI.Infrastructure.Services;

namespace bookAPI.Infrastructure.Database.Data
{
    public class DataBaseService : IDataBaseService
    {
        private readonly ILogger<DataBaseService> _logger;

        private readonly DataContext _dataContext;

        public DataBaseService(ILogger<DataBaseService> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

       
        //Employee
        public List<EmployeeRepository> GetEmployeesDb(string? name, string? employeeEmail)
        {
            try
            {
                IQueryable<EmployeeRepository> query = _dataContext.Employees.AsQueryable();
                if (name != null)
                {
                    query = query.Where(e => e.Name.Contains(name));
                }

                if (employeeEmail != null)
                {
                    query = query.Where(e => e.Email.Contains(employeeEmail));
                }
                return query.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new List<EmployeeRepository>();
            }
        }

        //User
        public bool AddUserDb(UserRepository user)
        {
            try
            {
                var userExists = _dataContext.Users.Where(x => x.Id == user.Id).FirstOrDefault();
                var userEmailExists = _dataContext.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                var incorrrectEmail = user.Email.Contains("@employee.com");

                if (userExists != null || userEmailExists != null)
                {
                    return false;
                }
                else if(incorrrectEmail)
                {
                    return false;
                }
                {
                    _dataContext.Users.Add(user);
                    _dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return false;
            }
        }
        public bool DeleteUserDb(int id)
        {
            try
            {
                var deleteUser = _dataContext.Users.Where(e => e.Id == id).FirstOrDefault();
                if (deleteUser == null)
                {
                    return false;
                }
                else
                {
                    _dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return false;
            }
        }
        public UserRepository GetSingleUserDb(int id)
        {
            try
            {
                var singleUser= _dataContext.Users?.Where(e => e.Id == id).FirstOrDefault();
                if (singleUser == null)
                {
                    return new UserRepository();
                }
                else
                {
                    return singleUser;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new UserRepository();
            }
        }
        public List<UserRepository> GetUsersDb()
        {
            try
            {
                return _dataContext.Users.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new List<UserRepository>();
            }
        }
        public UserRepository UpdateUserDb(int id, UserRepository user)
    
        {
            try
            {
                UserRepository updateUser = _dataContext.Users?.Where(e => e.Id == id).FirstOrDefault();
                UserRepository updateUserEmail = _dataContext.Users?.Where(e => e.Email == user.Email).FirstOrDefault();
                var incorrrectEmail = user.Email.Contains("@user.com");

                if (updateUser.Id == null || updateUserEmail != null && updateUserEmail.Id != updateUser.Id)
                {
                    return new UserRepository();
                }
                else if (incorrrectEmail)
                {
                    return new UserRepository();
                }
                else
                {
                    updateUser.Id = id;
                    updateUser.Name = user.Name;
                    updateUser.Email = user.Email;
                    updateUser.Password = user.Email;
                    updateUser.SignupDate = user.SignupDate;
                    updateUser.HasDiscount = user.HasDiscount;
                    updateUser.BookList = user.BookList;

                    _dataContext.SaveChanges();
                    return updateUser;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new UserRepository();
            }
        }

        public bool OrderBook(int bookId, int userId){
            return true;
        }
        public bool ReturnBook(int bookId, int userId){
            return true;
        }

        //Book
        public bool AddBookDb(int employeeId, BookRepository newBook)
        {
            try
            {
                var employeeExists = _dataContext.Employees?.Where(x => x.Id == employeeId).FirstOrDefault();
                var bookExists = _dataContext.Books?.Where(x => x.Id == newBook.Id).FirstOrDefault();
                
                if (employeeExists == null || bookExists.Name == newBook.Name)
                {
                    return false;
                }
                else
                {
                    var book = new BookRepository();
                    book.Name = newBook.Name;
                    book.Genre = newBook.Genre;
                    book.Stock = 10; 
                    book.Author = newBook.Author;
                    book.Price = newBook.Price;
                    book.IsInStock = true; 
                    book.DatePublished = DateTime.Now;
                    book.IsRemoved = false;


                    _dataContext.Books.Add(book);
                    _dataContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return false;
            }
        }

        public List<BookRepository> GetBooksUserDb(int employeeId, int userId)
        {
            
            try
            
            {
                EmployeeRepository employee = _dataContext.Employees?.Where(e => e.Id == employeeId).FirstOrDefault();
                var correctEmail = employee.Email.Contains("@employee.com");

                if (correctEmail == false){
                    return new List<BookRepository>();
                } else {
                    var userBookList = _dataContext.Users.Where(e => e.Id == userId).FirstOrDefault();
                    return userBookList.BookList;
                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message); 
                return new List<BookRepository>();
            }
        }

        public bool DeleteBookDb(int employeeId, int bookId)
        {
            try
            {
                EmployeeRepository employee = _dataContext.Employees?.Where(e => e.Id == employeeId).FirstOrDefault();
                var correctEmail = employee.Email.Contains("@employee.com");
                var bookExists = _dataContext.Books.Where(e => e.Id == bookId).FirstOrDefault();
               
                if (correctEmail == false || bookExists.Id == null){
                    return false;
                }else {
                    bookExists.IsRemoved = true;
                    _dataContext.SaveChanges();
                    return true;
                }
             
                
                
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return false;
            }
        }

        public BookRepository UpdateBookDb(int employeeId, int bookId, BookRepository book)
        {
            try
            {
                EmployeeRepository employee = _dataContext.Employees?.Where(e => e.Id == employeeId).FirstOrDefault();
                var correctEmail = employee.Email.Contains("@employee.com");
                BookRepository updateBook = _dataContext.Books?.Where(e => e.Id == bookId).FirstOrDefault();

                if (updateBook.Id == null || correctEmail == true)
                {
                    return new BookRepository();
                }
                else
                {
                    updateBook.Stock = book.Stock;
                    _dataContext.SaveChanges();
                    return updateBook;
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new BookRepository();
            }
        }

        public List<BookRepository> GetAllBooksDb(){
            return _dataContext.Books.ToList(); 
        }
    }
}
