using MovieApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication.Domain.Domain
{
    public class Order : BaseEntity
    {
        public string? UserId { get; set; }
        public MovieApplicationUser? User { get; set; }
        public virtual ICollection<TicketInOrder>? TicketInOrder { get; set; }
    }
}
