using AutoMapper;
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
    [Authorize(Roles = "Admin,Employee")]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;
        public TicketController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var ticketList = await _ticketService.TicketList();
            return View(ticketList);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var ticket = await GetTicketById(id);
            var ticketConvertVM = Convert(ticket);
            return View(ticketConvertVM);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var ticket = await GetTicketById(id);
            var ticketConvertVM = Convert(ticket);
            return View(ticketConvertVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(TicketConvertVM ticketConvertVM)
        {
            if (ModelState.IsValid)
            {
                var ticket = _mapper.Map<Ticket>(ticketConvertVM);
                await _ticketService.Update(ticket);
                return RedirectToAction("Index");
            }
            return View(ticketConvertVM);
        }
        [Authorize(Roles ="User,Admin,Employee")]
        [HttpGet]
        //public async Task<IActionResult> Create()
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TicketVM ticketVM)
        {
            if (ModelState.IsValid)
            {
                var ticket = _mapper.Map<Ticket>(ticketVM);
                await _ticketService.Create(ticket);
                return RedirectToAction("Index");
            }
            return View(ticketVM);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ticketService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            return await _ticketService.GetTicketById(id);
        }
        public TicketConvertVM Convert(Ticket ticket)
        {
            return _mapper.Map<TicketConvertVM>(ticket);
        }
    }
}
