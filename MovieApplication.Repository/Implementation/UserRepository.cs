using Microsoft.EntityFrameworkCore;
using MovieApplication.Domain.Identity;
using MovieApplication.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private DbSet<MovieApplicationUser> users;
        public UserRepository( ApplicationDbContext context)
        {
            _context = context;
            users = _context.Set<MovieApplicationUser>();
        }
        public void Delete(MovieApplicationUser entity)
        {
            users.Remove(entity);
            _context.SaveChanges();
        }

        public MovieApplicationUser Get(string? id)
        {
            return users.
                Include(x => x.Order).
                Include("Order.TicketInOrder").
                Include("Order.TicketInOrder.Ticket").
                Include("Order.TicketInOrder.Ticket.Movie").
                SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<MovieApplicationUser> GetAll()
        {
            return users.AsEnumerable();
        }

        public void Insert(MovieApplicationUser entity)
        {
            users.Add(entity);
            _context.SaveChanges();
        }

        public void Update(MovieApplicationUser entity)
        {
            users.Update(entity);
            _context.SaveChanges();
        }
    }
}
