using Debt_Notebook.Model.DoMain;
using Debt_Notebook.Model.DTOs.FilterDTO;
using Debt_Notebook.Model.DTOs.UserDTO;
using Debt_Notebook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Notebook.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService) {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetUserAll([FromQuery] UserFilterDTO userFilterDTO)
        {
            try
            {
                var result = _userService.GetUserAll(userFilterDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddUser(UserRequestDTO user)
        {
            try
            {
                var result = _userService.AddUser(user);
                return Ok(result);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, UserRequestDTO user)
        {
            try
            {
                var result = _userService.Edit(id, user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
             
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id) {
            try
            {
                var result = _userService.GetUserById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteUser(int id) {
            try
            {
                var result = _userService.DeleteUser(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
