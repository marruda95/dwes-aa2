using bookAPI.Domain.Models;
using bookAPI.Infrastructure.Contracts;
using bookAPI.Infrastructure.Data;
using bookAPI.Infrastructure.Database;
using bookAPI.Infrastructure.Models;

namespace bookAPI.Infrastructure.Service
{
    public interface IBookService
    {
        public bool AddBookInputModel(BookInputModel book);
        public List<BookRepository> GetBooksUser(int userId);
        public bool DeleteBook(int idBook);
        public bool UpdateBook( int bookId, BookInputModel book);
        public List<BookRepository> GetAllBooks();

    }
}