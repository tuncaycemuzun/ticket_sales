using Core.Concrete;
using Core.Dtos;
using Shared.Utilities.Filter;
using Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ITicketTypeService
    {
        Task<IResult> AddAsync(TicketTypeAddDto ticketTypeAddDto);
        Task<IResult> DeleteAsync(string id);
        Task<IDataResult<TicketTypeUpdateDto>> UpdateAsync(string id,TicketTypeUpdateDto ticketTypeUpdate);
        IDataResult<IList<TicketType>> Select(Expression<Func<TicketType, bool>> predicate = null, PaginationFilter filter = null);
    }
}
