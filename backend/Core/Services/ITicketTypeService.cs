using Core.Concrete;
using Core.Dtos;
using Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ITicketTypeService
    {
        Task<IResult> AddAsync(TicketTypeAddDto ticketTypeAddDto);
        Task<IResult> DeleteAsync(string id);
        Task<IDataResult<TicketTypeUpdateDto>> UpdateAsync(string id,TicketTypeUpdateDto ticketTypeUpdate);
        Task<IDataResult<IList<TicketType>>> GetAsync();
    }
}
