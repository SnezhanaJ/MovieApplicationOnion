using MovieApplication.Domain.Domain;
using MovieApplication.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Service.Interface
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        Ticket GetDetailsForTicket(Guid? id);
        void CreateNewTicket(Ticket p);
        void UpdateExistingTicket(Ticket p);
        void DeleteTicket(Guid id);
        AddToTicketInOrderDto GetOrderInfo(Guid? id);
        bool AddToOrder(AddToTicketInOrderDto item, string userId);
    }
}
