using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketTypeController : Controller
    {
        private readonly ITicketTypeService _ticketTypeService;
        public TicketTypeController(ITicketTypeService ticketTypeService)
        {
            _ticketTypeService = ticketTypeService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(TicketTypeAddDto ticketTypeAddDto)
        {
            var result = await _ticketTypeService.AddAsync(ticketTypeAddDto);
            return Ok(result);
        }


        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(TicketTypeDeleteDto ticketTypeDeleteDto)
        {
            var result = await _ticketTypeService.DeleteAsync(ticketTypeDeleteDto.Id);
            return Ok(result);
        }


        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(string id,TicketTypeUpdateDto ticketTypeUpdateDto)
        {
            var result = await _ticketTypeService.UpdateAsync(id,ticketTypeUpdateDto);
            return Ok(result);
        }
    }
}
