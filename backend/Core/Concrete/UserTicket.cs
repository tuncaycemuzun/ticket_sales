using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete
{
    public class UserTicket: BaseEntity
    {
        public User User { get; set; }
        public Ticket Ticket { get; set; }
    }
}
