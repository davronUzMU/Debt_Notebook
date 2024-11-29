using Debt_Notebook.Model.DoMain;
using Debt_Notebook.Model.DTOs.FilterDTO;
using Debt_Notebook.Model.DTOs.StateDTO;
using Debt_Notebook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Notebook.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StateService _stateService;
        public StateController(StateService stateService) { 
            _stateService = stateService;
        }
        [HttpGet]
        public IActionResult GetStateAll([FromQuery] StateFilterDTO stateFilterDTO)
        {
            try
            {
                 List<StateResponseDTO> states= _stateService.GetStateAll(stateFilterDTO);
                return Ok(states);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);  
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetStateById(int id) {
            try
            {
                var state = _stateService.GetStateById(id);
                return Ok(state);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
