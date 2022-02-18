using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Utilities.Filter;
using Shared.Utilities.Results.ComplexTypes;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class TicketTypeController : Controller
    {
        private readonly ITicketTypeService _ticketTypeService;
        public TicketTypeController(ITicketTypeService ticketTypeService)
        {
            _ticketTypeService = ticketTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(TicketTypeAddDto ticketTypeAddDto)
        {
            var result = await _ticketTypeService.AddAsync(ticketTypeAddDto);
            if (result.ResultCode == ResultCode.Success)
                return Ok(result);
            return BadRequest();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(TicketTypeDeleteDto ticketTypeDeleteDto)
        {
            var result = await _ticketTypeService.DeleteAsync(ticketTypeDeleteDto.Id);
            if (result.ResultCode == ResultCode.Success)
                return Ok(result);
            return BadRequest();
        }


        [HttpPut]
        public async Task<IActionResult> Update(string id, TicketTypeUpdateDto ticketTypeUpdateDto)
        {
            var result = await _ticketTypeService.UpdateAsync(id, ticketTypeUpdateDto);
            if (result.ResultCode == ResultCode.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Select(PaginationFilter filter)
        {
            var result = _ticketTypeService.Select(x=>x.IsDeleted==false, filter);
            if (result.ResultCode == ResultCode.Success)
                return Ok(result);
            return BadRequest();
        }

    }
}
