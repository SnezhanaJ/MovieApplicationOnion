

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApplication.Domain.Domain;
using MovieApplication.Domain.Identity;

namespace MovieApplication.Repository
{
    public class ApplicationDbContext : IdentityDbContext<MovieApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketInOrder> TicketsInOrder { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
