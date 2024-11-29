using Debt_Notebook.Model.DTOs;
using Debt_Notebook.Model.DTOs.MessageDTO;
using Debt_Notebook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Debt_Notebook.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class PlayMobileActivationController : ControllerBase
    {
        private readonly PlayMobileSMSService playMobileSMSService;
        public PlayMobileActivationController(PlayMobileSMSService service) {
            this.playMobileSMSService = service;
        }
        [HttpPost("activate")]
        public async Task<IActionResult> activate(PlayMobileActivationDTO mobileActivationDTO) {
            try
            {
                var result= await playMobileSMSService.Activate(mobileActivationDTO);
                return Ok(result);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("send-sms")]
        public async Task<IActionResult> sendSMS([FromBody] MessageRequestDTO messageRequestDTO, [FromQuery] PlayMobileActivationDTO playMobileActivationDTO)
        {
            try
            {
                var result = await playMobileSMSService.SendSMS(messageRequestDTO, playMobileActivationDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
