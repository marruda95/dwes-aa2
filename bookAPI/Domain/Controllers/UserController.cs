using bookAPI.Domain.Models;
using bookAPI.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookAPI.Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("/User/")]
        public ActionResult AddUser(UserInputModel user)
        {
            try
            {
                _logger.LogWarning($"Method AddBook invoked.");
                
                string admin = HttpContext.User.Identity.Name;

                bool boookStatus = _userService.AddUser(user);
                if (boookStatus)
                {
                    return Ok("User added");
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

        [HttpDelete("/User/{idUser}")]
        public ActionResult RemoveBook(int idUser)
        {
            try
            {
                _logger.LogWarning($"Method RemoveBook invoked.");
               
                string admin = HttpContext.User.Identity.Name;

                bool boookStatus = _userService.DeleteUser(idUser);
                if (boookStatus)
                {
                    return Ok("User removed");
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

        [HttpGet("/Users/")]
        public ActionResult GetUsers()
        {
            try
            {
                _logger.LogWarning($"Method GetUsers invoked.");

                var users = _userService.GetUsers();
                if (users.Count > 0)
                {
                    return Ok(users);
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

        [HttpGet("/User/{userId}")]
        public ActionResult GetUser(int userId)
        {
            try
            {
                _logger.LogWarning($"Method GetUser invoked.");

                var user = _userService.GetSingleUser(userId);
                if (user.Name != null)
                {
                    return Ok(user);
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

        [HttpPut("/User/{idUser}")]
        public ActionResult updateUser(int idUser, UserInputModel user)
        {
            try
            {
                _logger.LogWarning($"Method updateUser invoked.");

                var bookUpdated = _userService.UpdateUser(idUser, user);
                if (bookUpdated)
                {
                    return Ok("User updated");
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

        [HttpPut("/User/{idUser}/Order/{bookId}")]
        public ActionResult OrderBook(int bookId, int idUser)
        {
            try
            {
                _logger.LogWarning($"Method OrderBook invoked.");

                var bookOrdererd = _userService.OrderBook(bookId, idUser);
                if (bookOrdererd)
                {
                    return Ok("book Ordererd");
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

        [HttpPut("/User/{idUser}/Return/{bookId}")]
        public ActionResult ReturnBook(int bookId, int idUser)
        {
            try
            {
                _logger.LogWarning($"Method ReturnBook invoked.");
                
                var bookOrdererd = _userService.ReturnBook(bookId, idUser);
                if (bookOrdererd)
                {
                    return Ok("book Returned");
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
