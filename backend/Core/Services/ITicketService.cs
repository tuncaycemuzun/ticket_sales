using Core.Concrete;
using Core.Dtos;
using MongoDB.Bson;
using Shared.Utilities.Results.Abstract;

namespace Core.Services
{
    public interface ITicketService
    {
        Task<IResult> AddAsync(TicketAddDto ticketAddDto);
        Task<IResult> DeleteAsync(string id);
        Task<IDataResult<TicketUpdateDto>> UpdateAsync(string id,TicketUpdateDto ticketUpdateDto);
        Task<IDataResult<IList<TicketDto>>> GetAsync();
    }
}
