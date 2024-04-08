using MovieApplication.Domain.Domain;
using MovieApplication.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Service.Interface
{
    public interface IOrderService
    {
        TicketInOrderDto GetDetailsForOrder(string? userId);
        bool DeleteTicketFromOrder(string userId, Guid ticketId);
        bool orderNow(string userId);
    }
}
