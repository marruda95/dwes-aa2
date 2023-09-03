using bookAPI.Domain.Models;
using bookAPI.Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookAPI.Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //TODO

        //BORRAR DATABASE


        //ADD MIGRATION
        //UPDATE DATABASE

        //ADD ADMIN
        //ADD USER
        //ADD BOOK


        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpPost("/Book/")]
        public ActionResult AddBook(BookInputModel bookInputModel)
        {
            try
            {
                _logger.LogWarning($"Method AddBook invoked.");
                string admin = HttpContext.User.Identity.Name;

                bool boookStatus = _bookService.AddBookInputModel(bookInputModel);
                if (boookStatus)
                {
                    return Ok("Book added");
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("/Book/{idBook}")]
        public ActionResult RemoveBook(int idBook)
        {
            try
            {
                _logger.LogWarning($"Method RemoveBook invoked.");
                string admin = HttpContext.User.Identity.Name;

                bool boookStatus = _bookService.DeleteBook(idBook);
                if (boookStatus)
                {
                    return Ok("Book removed");
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }
        }


        [HttpGet("/Books/")]
        public ActionResult GetBooks()
        {
            try
            {
                _logger.LogWarning($"Method GetBooks invoked.");

                var books = _bookService.GetAllBooks();
                if (books.Count > 0)
                {
                    return Ok(books);
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("/Book/{idBook}")]
        public ActionResult updateBook(int idBook, BookInputModel book)
        {
            try
            {
                _logger.LogWarning($"Method updateBook invoked.");

                var bookUpdated = _bookService.UpdateBook(idBook, book);
                if (bookUpdated)
                {
                    return Ok("Book updated");
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("/Books/{userId}")]
        public ActionResult GetUserBooks(int userId)
        {
            try
            {
                _logger.LogWarning($"Method GetUserBooks invoked.");

                var books = _bookService.GetBooksUser(userId);
                if (books.Count > 0)
                {
                    return Ok(books);
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }
        }
    }
}
