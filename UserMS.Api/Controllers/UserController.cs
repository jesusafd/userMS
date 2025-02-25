using Microsoft.AspNetCore.Mvc;
using UserMS.Application.Commands.User;
using UserMS.Application.Dtos.User;
using UserMS.Application.Queries.User;

namespace User_MS.Api.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserQueries _userQueries;
        private readonly IUserCommands _userCommands;
        public UserController(
            IUserQueries userQueries, 
            IUserCommands userCommands
            )
        {
            _userQueries = userQueries;
            _userCommands = userCommands;
        }

        [HttpGet("/")]
        public async Task<ActionResult> Index()
        {
            return Ok(new {Message = "Hola desde el controlador User"});
        }

        [HttpPost("user")]
        public async Task<ActionResult> PostUser(UserDto  user)
        {
            var result = _userCommands.PostUser(user);
            return result != null ? Ok(result) : BadRequest(new {Message = "Error al insertar datos"});
        }

        [HttpGet("user")]
        public async Task<ActionResult> GetUser(string mail)
        {
            var result = _userQueries.GetUserByEmail(mail);
            return result != null ? Ok(result) : BadRequest(new { Message = "Error al buscar datos" });
        }


    }
}
