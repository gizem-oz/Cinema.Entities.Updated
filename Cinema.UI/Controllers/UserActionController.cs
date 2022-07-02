using Cinema.Business.Abstract;
using Cinema.Entities.Concrete;
using Cinema.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Controllers
{
    [Authorize(Roles ="User")]
    public class UserActionController : Controller
    {
        public readonly IMovieService _movieService;
        public readonly ITicketService _ticketService;
        public UserActionController(ITicketService ticketService, IMovieService movieService)
        {
            _movieService = movieService;
            _ticketService = ticketService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(TicketAndMovieVM model)
        {
            var movie = await _movieService.GetMovieById(model.Id);
            var ticket = new Ticket { ReservationId = model.ReservationId, Price = 100, SessionId = model.SessionId, Status = false, BuyDate = model.BuyDate};
            await _ticketService.Create(ticket);
            return RedirectToAction("Index");
        }
    }
}
