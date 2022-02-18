using Core.Abstract;
using Core.Concrete;
using Data.Settings;
using Microsoft.Extensions.Options;

namespace Data.Repositories
{
    public class TicketTypeRepository : MongoDbRepositoryBase<TicketType>, ITicketTypeRepository
    {
        public TicketTypeRepository(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
