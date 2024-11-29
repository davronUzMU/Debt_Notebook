using Debt_Notebook.Model.DTOs.FilterDTO;
using Debt_Notebook.Model.DTOs.OrganizationDTO;
using Debt_Notebook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Notebook.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly OrganizationService _organizationService;
        public OrganizationController(OrganizationService organizationService) { 
            _organizationService = organizationService;
        }
        [HttpGet]
        public IActionResult GetOrganizationAll([FromQuery] OrganizationFilterDTO organizationFilterDTO)
        {
            try
            {
                var result = _organizationService.GetOrganizationAll(organizationFilterDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetOrganizationById(int id)
        {
            try
            {
                var result = _organizationService.GetOrganizationById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrganization(int id) {
            try
            {
                var result = _organizationService.DeleteOrganization(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id ,OrganizationAddOrEditRequestDTO organizationAddOrEditRequestDTO)
        {
            try
            {
                var result = _organizationService.Edit(id, organizationAddOrEditRequestDTO);
                return Ok(result);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }   
        }
        [HttpPost]
        public IActionResult AddOrganization(OrganizationAddOrEditRequestDTO organizationAddOrEditRequestDTO) {

            try
            {
                var result = _organizationService.AddOrganization(organizationAddOrEditRequestDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
