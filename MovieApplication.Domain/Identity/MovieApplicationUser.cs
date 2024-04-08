using Microsoft.AspNetCore.Identity;
using MovieApplication.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Domain.Identity
{
    public class MovieApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Ticket> MyTickets { get; set; }
        public Order Order { get; set; }
    }
}
