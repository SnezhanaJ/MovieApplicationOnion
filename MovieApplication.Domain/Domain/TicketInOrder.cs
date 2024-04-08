using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Domain.Domain
{
    public class TicketInOrder : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public Guid TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
