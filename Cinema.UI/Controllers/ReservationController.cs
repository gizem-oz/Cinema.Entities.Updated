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
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var reservationList = await _reservationService.GetAllReservationList();
            return View(reservationList);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var reservation = await GetReservationById(id);
            var reservationConvertVM = Convert(reservation);
            return View(reservationConvertVM);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var reservation = await GetReservationById(id);
            var reservationConvertVM = Convert(reservation);
            return View(reservationConvertVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ReservationConvertVM reservationConvertVM)
        {
            if (ModelState.IsValid)
            {
                var reservation = _mapper.Map<Reservation>(reservationConvertVM);
                await _reservationService.Update(reservation);
                return RedirectToAction("Index");
            }
            return View(reservationConvertVM);
        }
        [HttpGet]
        //public async Task<IActionResult> Create()
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ReservationVM reservationVM)
        {
            if (ModelState.IsValid)
            {
                var reservation = _mapper.Map<Reservation>(reservationVM);
                await _reservationService.Add(reservation);
                return RedirectToAction("Index");
            }
            return View(reservationVM);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reservationService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _reservationService.GetReservationById(id);
        }
        public ReservationConvertVM Convert(Reservation reservation)
        {
            return _mapper.Map<ReservationConvertVM>(reservation);
        }
    }
}
