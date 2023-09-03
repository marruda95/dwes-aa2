using bookAPI.Infrastructure.Models;
using bookAPI.Infrastructre.Context;
using bookAPI.Infrastructure.Data;

namespace bookAPI.Infrastructure.Database
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
                    _dataContext.Remove(deleteUser);
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
                var users = _dataContext.Users.ToList();
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return new List<UserRepository>();
            }
        }
        public bool UpdateUserDb(int id, UserRepository user)
    
        {
            try
            {
                UserRepository updateUser = _dataContext.Users?.Where(e => e.Id == id).FirstOrDefault();
                UserRepository updateUserEmail = _dataContext.Users?.Where(e => e.Email == user.Email).FirstOrDefault();
                var incorrrectEmail = user.Email.Contains("@employee.com");

                if (updateUser.Id == null || updateUserEmail != null && updateUserEmail.Id != updateUser.Id)
                {
                    return false;
                }
                else if (incorrrectEmail)
                {
                    return false;
                }
                else
                {
                    updateUser.Id = id;
                    updateUser.Name = user.Name;
                    updateUser.Email = user.Email;
                    updateUser.Password = user.Password;
                    updateUser.SignupDate = user.SignupDate;
                    updateUser.HasDiscount = user.HasDiscount;

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

        public bool OrderBook(int bookId, int userId){
            
            var book = _dataContext.Books?.Where(e => e.Id == bookId).FirstOrDefault();
            var user = _dataContext.Users?.Where(e => e.Id == userId).FirstOrDefault();


            if (book == null || user == null || book.IsInStock == false || book.Stock < 1)
            {
                return false;
            }
            else
            {
                var order = new OrderRepository { BookId= bookId, UserId = userId };
                _dataContext.Orders.Add(order);

                book.Stock = book.Stock - 1;
                if (book.Stock < 1)
                {
                    book.IsInStock = false;
                }
                _dataContext.SaveChanges();
                return true;
                  
            }
        }

        public bool ReturnBook(int bookId, int userId){

            var book = _dataContext.Books?.Where(e => e.Id == bookId).FirstOrDefault();
            var user = _dataContext.Users?.Where(e => e.Id == userId).FirstOrDefault();

            if (book == null || user == null || book.IsInStock == false || book.Stock < 1)
            {
                return false;
            }
            else
            {
                var order = _dataContext.Orders?.Where(e => e.UserId == bookId && e.UserId == userId).FirstOrDefault();

                if (order == null)
                {
                    return false;
                }
                else
                {
                    _dataContext.Orders.Remove(order);

                    book.Stock = book.Stock + 1;
                    if (book.Stock > 0)
                    {
                        book.IsInStock = true;
                    }
                    _dataContext.SaveChanges();
                    return true;
                }
            }
        }

        //Book
        public bool AddBookDb(BookRepository newBook)
        {
            try
            {
                //var employeeExists = _dataContext.Employees?.Where(x => x.Id == employeeId).FirstOrDefault();
                var bookExists = _dataContext.Books?.Where(x => x.Id == newBook.Id).FirstOrDefault();
                
                if  (bookExists != null && bookExists.Name == newBook.Name) // chekear que el libro que se mete no esta repetido
                {
                    return false;
                }
                else
                {
                    var book = new BookRepository();
                    book.Name = newBook.Name;
                    book.Genre = newBook.Genre;
                    book.Stock = newBook.Stock; 
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

        public List<BookRepository> GetBooksUserDb(int userId)
        {
            
            try
            {
                //EmployeeRepository employee = _dataContext.Employees?.Where(e => e.Id == employeeId).FirstOrDefault();
                //var correctEmail = employee.Email.Contains("@employee.com");
                var userBookList = _dataContext.Users.Where(e => e.Id == userId).FirstOrDefault();
                var userBooks = _dataContext.Orders.Where(e => e.UserId == userId).ToList();



                if (userBookList == null || userBooks.Count < 1)
                {
                    return new List<BookRepository>();
                }
                else
                {
                    var list = new List<BookRepository>();
                    foreach (var item in userBooks)
                    {
                        var book = _dataContext.Books.Where(e => e.Id == item.BookId).FirstOrDefault();
                        if(book != null)
                        {
                            list.Add(book);
                        }
                        else
                        {
                            return new List<BookRepository>();
                        }
                    }
                    return list;
                }
                    
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message); 
                return new List<BookRepository>();
            }
        }

        public bool DeleteBookDb(int bookId)
        {
            try
            {
                //EmployeeRepository employee = _dataContext.Employees?.Where(e => e.Id == employeeId).FirstOrDefault();
                //var correctEmail = employee.Email.Contains("@employee.com");
                var bookExists = _dataContext.Books.Where(e => e.Id == bookId).FirstOrDefault();
               
                if (bookExists == null)
                {
                    return false;
                } 
                else 
                {
                    var orders = _dataContext.Orders.Where(e => e.BookId == bookId).ToList();
                    foreach (var item in orders)
                    {
                        _dataContext.Orders.Remove(item);
                    }

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

        public bool UpdateBookDb(int bookId, BookRepository book)
        {
            try
            {
                //EmployeeRepository employee = _dataContext.Employees?.Where(e => e.Id == employeeId).FirstOrDefault();
                //var correctEmail = employee.Email.Contains("@employee.com");
                BookRepository updateBook = _dataContext.Books?.Where(e => e.Id == bookId).FirstOrDefault();

                if (updateBook == null)
                {
                    return false;
                }
                else
                {
                    updateBook.Id = bookId;
                    updateBook.Name = book.Name;
                    updateBook.Author = book.Author;    
                    updateBook.Genre= book.Genre;
                    updateBook.Price= book.Price;
                    updateBook.DatePublished = book.DatePublished;
                    updateBook.IsInStock= book.IsInStock;
                    updateBook.Stock= book.Stock;
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

        public List<BookRepository> GetAllBooksDb(){
            return _dataContext.Books.ToList(); 
        }
    }
}
