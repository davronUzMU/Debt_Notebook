using Debt_Notebook.Model.DTOs.DebtDTO;
using Debt_Notebook.Model.DTOs.FilterDTO;
using Debt_Notebook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Notebook.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DebtController : ControllerBase
    {
        private readonly DebtService _btService;
        public DebtController(DebtService btService) {
            _btService = btService;
        }
        [HttpGet]
        public IActionResult GetDebtAll([FromQuery] DebtFilterDTO debtFilterDTO) {
            try
            {
                var result = _btService.GetDebtAll(debtFilterDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetDebtById(int id)
        {
            try
            {
                var result = _btService.GetDebtById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Add/{id}")]
        public IActionResult EditAddPrise(int id,DebtRequestDTO debtRequestDTO)
        {
            try
            {
                var result = _btService.EditAddPrise(id, debtRequestDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }
        [HttpPut("Sub/{id}")]
        public IActionResult EditSubPrise(int id, DebtRequestDTO debtRequestDTO)
        {
            try
            {
                var result = _btService.EditSubPrise(id, debtRequestDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddDebt(DebtRequestDTO debtRequestDTO) {
            try
            {
                var result = _btService.AddDebt(debtRequestDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id) {
            try
            {
                var result = _btService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
