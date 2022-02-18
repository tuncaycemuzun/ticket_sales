using Core.Concrete;
using Shared.Utilities.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Abstract
{
    public interface ITicketTypeRepository : IRepository<TicketType>
    {
        IEnumerable<TicketType> ListWithParams(Expression<Func<TicketType, bool>> predicate = null,PaginationFilter filter=null);
    }
}
