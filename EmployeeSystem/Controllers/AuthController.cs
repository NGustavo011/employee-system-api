using EmployeeSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeSystem.Application.Services;

namespace EmployeeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ActionResult Auth(string username, string password)
        {
            if(username == "valid_user" && password == "valid_pass")
            {
                object token = TokenService.GenerateToken(new Employee("pato", 1, ""));
                return Ok(token);
            }
            return BadRequest("Username or password invalid");
        }
    }
}
