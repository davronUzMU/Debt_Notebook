using Debt_Notebook.Model.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Notebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles= "SUBER_ADMIN")]
        public IActionResult GenerationPassword()
        {
            return null;
        } 
        [HttpPost("login")]
        public IActionResult Login()
        {
            return null;
        }
    }
}
