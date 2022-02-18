using Core.Abstract;
using Core.Concrete;
using Core.Dtos;
using Core.Services;
using MongoDB.Bson;
using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repo;
        public TicketService(ITicketRepository repo)
        {
            _repo = repo;
        }

        public async Task<IResult> AddAsync(TicketAddDto ticketAddDto)
        {
            var ticket = ObjectMapper.Mapper.Map<Ticket>(ticketAddDto);
            var result = await _repo.AddAsync(ticket);
            if (result == null) return new Result(ResultCode.BadRequest);
            return new Result(ResultCode.Success);
        }

        public async Task<IResult> DeleteAsync(string id)
        {
            var entity = await _repo.GetAsync(x => x.Id.ToString() == id);
            if (entity == null) return new Result(ResultCode.NotFound,Messages.Ticket.NotFound());

            await _repo.DeleteAsync(entity);
            return new Result(ResultCode.Success, Messages.Ticket.Success());
        }

        public Task<IDataResult<IList<TicketDto>>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<TicketUpdateDto>> UpdateAsync(string id,TicketUpdateDto ticketUpdateDto)
        {
            var entity = await _repo.GetAsync(x => x.Id.ToString() == id);
            if(entity==null) return new DataResult<TicketUpdateDto>(ResultCode.NotFound, Messages.Ticket.NotFound());
            var ticket = ObjectMapper.Mapper.Map<TicketUpdateDto>(entity);
            await _repo.UpdateAsync(entity.Id.ToString(), entity);
            return new DataResult<TicketUpdateDto>(ResultCode.Success, Messages.Ticket.Success(), ticket);
        }
    }
}
