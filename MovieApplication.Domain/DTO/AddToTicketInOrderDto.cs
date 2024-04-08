using MovieApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Domain.DTO
{
    public class AddToTicketInOrderDto
    {
        public Guid TicketId { get; set; }
        public Ticket? SelectedTicket { get; set; }
        public int NumberOrTickets { get; set; }
    }
}
