using AutoMapper;
using Cinema.Business.Abstract;
using Cinema.Entities.Concrete;
using Cinema.UI.Models.ViewModels;
using Cinema.UI.Models.ViewModels.ViewModelBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class SeatController : Controller
    {
        private readonly ISeatService _seatService;
        private readonly IMapper _mapper;
        public SeatController(ISeatService seatService, IMapper mapper)
        {
            _seatService = seatService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var seatList = await _seatService.GetSeatList();
            return View(seatList);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var seat = await GetSeatById(id);
            var seatConvertVM = Convert(seat);
            return View(seatConvertVM);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var seat = await GetSeatById(id);
            var seatConvertVM = Convert(seat);
            return View(seatConvertVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SeatConvertVM seatConvertVM)
        {
            if (ModelState.IsValid)
            {
                var seat = _mapper.Map<Seat>(seatConvertVM);
                await _seatService.Update(seat);
                return RedirectToAction("Index");
            }
            return View(seatConvertVM);
        }
        [HttpGet]
        //public async Task<IActionResult> Create()
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SeatVM seatVM)
        {
            if (ModelState.IsValid)
            {
                var seat = _mapper.Map<Seat>(seatVM);
                await _seatService.Add(seat);
                return RedirectToAction("Index");
            }
            return View(seatVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _seatService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<Seat> GetSeatById(int id)
        {
            return await _seatService.GetSeatById(id);
        }
        public SeatConvertVM Convert(Seat seat)
        {
            return _mapper.Map<SeatConvertVM>(seat);
        }
    }
}
