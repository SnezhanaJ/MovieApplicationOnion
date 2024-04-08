using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApplication.Domain.Domain;
using MovieApplication.Domain.DTO;
using MovieApplication.Service.Interface;


namespace MovieApplication.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IMovieService _movieService;

        public TicketsController(ITicketService ticketService, IMovieService movieService)
        {
            _ticketService = ticketService;
            _movieService = movieService;
        }

        // GET: Tickets
        public IActionResult Index()
        {

            var tickets = _ticketService.GetAllTickets();
            return View(tickets);
           // var applicationDbContext = _context.Tickets.Include(t => t.Movie);
           // return View(await applicationDbContext.ToListAsync());
        }
        // Details is the same as AddToOrder because i couldn't create a view in onion..
        public IActionResult Details(Guid id)
        {
           var dto = _ticketService.GetOrderInfo(id);
            return View(dto);
        }
        [HttpPost]
        public IActionResult Details(AddToTicketInOrderDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _ticketService.AddToOrder(model, userId);
            if (result)
            {
                return RedirectToAction("Index", "Orders");
            }
            return RedirectToAction("Index", "Tickets");
        }



        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_movieService.GetAllMovies(), "Id", "MovieDescription");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Price,MovieId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _ticketService.CreateNewTicket(ticket);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_movieService.GetAllMovies(), "Id", "MovieDescription", ticket.MovieId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_movieService.GetAllMovies(), "Id", "MovieDescription", ticket.MovieId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Price,MovieId")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ticketService.UpdateExistingTicket(ticket);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_movieService.GetAllMovies(), "Id", "MovieDescription", ticket.MovieId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _ticketService.DeleteTicket(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
            var ticket = _ticketService.GetDetailsForTicket(id);
            return ticket != null;
        }
    }
}
