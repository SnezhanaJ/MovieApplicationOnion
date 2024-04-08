using MovieApplication.Domain.Domain;
using MovieApplication.Domain.DTO;
using MovieApplication.Repository.Interface;
using MovieApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Service.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Order> _orderRepository;
        public TicketService(IRepository<Ticket> ticketRepository, IUserRepository userRepository, IRepository<Order> orderRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public void CreateNewTicket(Ticket p)
        {
            _ticketRepository.Insert(p);
        }

        public void DeleteTicket(Guid id)
        {
            var ticket = _ticketRepository.Get(id);
            _ticketRepository.Delete(ticket);
        }

        public List<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAll().ToList();
        }

        public Ticket GetDetailsForTicket(Guid? id)
        {
            return _ticketRepository.Get(id);
        }

        public AddToTicketInOrderDto GetOrderInfo(Guid? id)
        {
            var ticket = _ticketRepository.Get(id);

            var dto = new AddToTicketInOrderDto
            {
                TicketId = ticket.Id,
                NumberOrTickets = 1,
                SelectedTicket = ticket,
            };
            return dto;
        }
        public bool AddToOrder(AddToTicketInOrderDto item, string userId)
        {
            var user = _userRepository.Get(userId);
            var userOrder = user.Order;
            var selectedTicket = _ticketRepository.Get(item.TicketId);
            if (userOrder != null && selectedTicket!=null)
            {
                userOrder.TicketInOrder.Add(new TicketInOrder
                {
                    Ticket = selectedTicket,
                    TicketId=selectedTicket.Id,
                    Order = userOrder,
                    OrderId = userOrder.Id,
                    NumberOfTickets = item.NumberOrTickets,
                });
                _orderRepository.Update(userOrder);
                return true;
            }
            return false;
        }

        public void UpdateExistingTicket(Ticket p)
        {
            _ticketRepository.Update(p);
        }
    }
}
