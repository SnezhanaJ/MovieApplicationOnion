using MovieApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Domain.DTO
{
    public class TicketInOrderDto
    {
        public List<TicketInOrder> allTickets { get; set; }
        public double totalPrice;
    }
}
