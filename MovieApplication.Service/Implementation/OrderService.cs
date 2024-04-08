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
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Ticket> _ticketRepository;
        public OrderService(IRepository<Order> orderRepository, IUserRepository userRepository, IRepository<Ticket> ticketRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
        }
        public bool DeleteTicketFromOrder(string userId, Guid ticketId)
        {
            var user = _userRepository.Get(userId);
            var userOrder = user.Order;
            var ticket_to_delete = userOrder.TicketInOrder.Where(m=>m.Id==ticketId).FirstOrDefault();
            userOrder.TicketInOrder.Remove(ticket_to_delete);
            _orderRepository.Update(userOrder);
            return true;

        }

        public TicketInOrderDto GetDetailsForOrder(string? userId)
        {
            var user = _userRepository.Get(userId);
            var userOrder = user.Order;
            var allTickets = userOrder.TicketInOrder.ToList();
            var total = 0.0;
            foreach (var ticket in allTickets)
            {
                total += ticket.Ticket.Price * ticket.NumberOfTickets;
            }
            var dto = new TicketInOrderDto
            {
                allTickets = allTickets,
                totalPrice = total,
            };
            return dto;
        }

        public bool orderNow(string userId)
        {
            var user = _userRepository.Get(userId);
            var userOrder = user.Order;
            userOrder.TicketInOrder.Clear();
            _orderRepository.Update(userOrder);
            return true;

        }
           
        
    }
}
