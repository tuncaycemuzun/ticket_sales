using Core.Abstract;
using Core.Concrete;
using Data.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shared.Utilities.Filter;
using System.Collections.Generic;
using System.Linq.Expressions;
using X.PagedList;
namespace Data.Repositories
{
    public class TicketTypeRepository : MongoDbRepositoryBase<TicketType>, ITicketTypeRepository
    {
        public TicketTypeRepository(IOptions<MongoDbSettings> options) : base(options)
        {
        }
        public IEnumerable<TicketType> ListWithParams(Expression<Func<TicketType, bool>> predicate = null, PaginationFilter filter = null)
        {
            var data = Collection.AsQueryable().Where(predicate).ToPagedList(filter.PageNumber, filter.PageSize);
            return data;
        }
    }
}
