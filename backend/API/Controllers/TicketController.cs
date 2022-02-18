using Core.Concrete;
using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Utilities.Results.ComplexTypes;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(TicketAddDto ticketAddDto)
        {
            var result = await _ticketService.AddAsync(ticketAddDto);
            if(result.ResultCode == ResultCode.Success)
                return Ok(result);
            return BadRequest();
        }


        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _ticketService.DeleteAsync(id);
            if (result.ResultCode == ResultCode.Success)
                return Ok(result);
            return BadRequest();
        }


        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(string id,TicketUpdateDto ticketUpdateDto)
        {
            var result = await _ticketService.UpdateAsync(id,ticketUpdateDto);
            if (result.ResultCode == ResultCode.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
