using MovieApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Domain.Domain
{
    public class Ticket : BaseEntity
    {
        [Required]
        public double Price { get; set; }
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; }
        public virtual MovieApplicationUser? CreatedBy { get; set; }
        public virtual ICollection<TicketInOrder>? TicketsInOrder { get; set; }
    }
}
