using bookAPI.Domain.Models;
using bookAPI.Infrastructure.Data;
using bookAPI.Infrastructure.Models;

namespace bookAPI.Infrastructure.Service
{
    public class BookService : IBookService
    {
        private readonly IDataBaseService _databaseService;
        public BookService(IDataBaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public bool AddBookInputModel(BookInputModel book)
        {
            if(book == null)
            {
                return false;
            }
            else
            {
                var bookRepository = new BookRepository();
                bookRepository.Name = book.Name;    
                bookRepository.Author = book.Author;
                bookRepository.Genre = book.Genre;
                bookRepository.Price = book.Price;
                bookRepository.DatePublished = book.DatePublished;
                bookRepository.IsInStock = book.IsInStock;
                bookRepository.Stock = book.Stock;
                bookRepository.IsRemoved = book.IsRemoved;

                return _databaseService.AddBookDb(bookRepository);
            }
        }

        public bool DeleteBook(int idBook)
        {
            if(idBook < 0) 
            {
                return false;
            }
            else
            {
                return _databaseService.DeleteBookDb(idBook);
                
            }
        }

        public List<BookRepository> GetAllBooks()
        {
            var booksDb =_databaseService.GetAllBooksDb();
            if (booksDb.Count > 0)
            {
                return booksDb;
            }
            else
            {
                return new List<BookRepository>();
            }
        }

        public List<BookRepository> GetBooksUser(int userId)
        {
            if(userId < 1)
            {
                return new List<BookRepository>();
            }
            else
            {
                return _databaseService.GetBooksUserDb(userId);
            }

        }

        public bool UpdateBook(int bookId, BookInputModel book)
        {
           if(bookId < 0 || book.Name == null) 
            {
                return false;
            }
           else
            {
                var bookDb = new BookRepository();
                bookDb.Name = book.Name;
                bookDb.Author = book.Author;
                bookDb.Genre = book.Genre;
                bookDb.Price = book.Price;
                bookDb.DatePublished = book.DatePublished;
                bookDb.IsInStock = book.IsInStock;
                bookDb.Stock = book.Stock;
                book.IsRemoved = book.IsRemoved;

                return _databaseService.UpdateBookDb(bookId, bookDb);
            }
        }
    }
}
