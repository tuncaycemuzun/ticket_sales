using Core.Abstract;
using Core.Concrete;
using Core.Dtos;
using Core.Services;
using MongoDB.Bson;
using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using Shared.Utilities.Results.Concrete;

namespace Services.Concrete
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly ITicketTypeRepository _repo;
        public TicketTypeService(ITicketTypeRepository repo)
        {
            _repo = repo;
        }
        public async Task<IResult> AddAsync(TicketTypeAddDto ticketTypeAddDto)
        {
            var ticket = ObjectMapper.Mapper.Map<TicketType>(ticketTypeAddDto);
            await _repo.AddAsync(ticket);
            return new Result(ResultCode.Success);
        }

        public async Task<IResult> DeleteAsync(string id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return new Result(ResultCode.NotFound);
            await _repo.DeleteAsync(entity);
            return new Result(ResultCode.Success);
        }

        public Task<IDataResult<IList<TicketType>>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<TicketTypeUpdateDto>> UpdateAsync(string id,TicketTypeUpdateDto ticketTypeUpdate)
        {
            var entity = ObjectMapper.Mapper.Map<TicketType>(ticketTypeUpdate);
            await _repo.UpdateAsync(id, entity);
            return new DataResult<TicketTypeUpdateDto>(ResultCode.Success, Messages.Ticket.Success(), ticketTypeUpdate);

        }
    }
}
