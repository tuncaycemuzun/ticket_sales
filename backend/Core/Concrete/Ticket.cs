using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete
{
    public class Ticket : BaseEntity
    {
        public int Seller { get; set; }
        public double Price { get; set; }
        public TicketType Type { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
