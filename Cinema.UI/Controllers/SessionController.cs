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
    [Authorize(Roles = "Admin")]
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;
        public SessionController(ISessionService sessionService, IMapper mapper)
        {
            _sessionService = sessionService;
            _mapper = mapper;
        }
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Index()
        {
            var sessionList = await _sessionService.SessionList();
            return View(sessionList);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Details(int id)
        {
            var session = await GetSessionById(id);
            var sessionConvertVM = Convert(session);
            return View(sessionConvertVM);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var session = await GetSessionById(id);
            var sessionConvertVM = Convert(session);
            return View(sessionConvertVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SessionConvertVM sessionConvertVM)
        {
            if (ModelState.IsValid)
            {
                var session = _mapper.Map<Session>(sessionConvertVM);
                await _sessionService.Update(session);
                return RedirectToAction("Index");
            }
            return View(sessionConvertVM);
        }
        [HttpGet]
        //public async Task<IActionResult> Create()
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SessionVM sessionVM)
        {
            if (ModelState.IsValid)
            {
                var session = _mapper.Map<Session>(sessionVM);
                await _sessionService.Add(session);
                return RedirectToAction("Index");
            }
            return View(sessionVM);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sessionService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<Session> GetSessionById(int id)
        {
            return await _sessionService.GetSessionById(id);
        }
        public SessionConvertVM Convert(Session session)
        {
            return _mapper.Map<SessionConvertVM>(session);
        }
    }
}
