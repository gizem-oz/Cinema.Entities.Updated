using Cinema.Business.Abstract;
using Cinema.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var result = await _authService.Login(model);
            if (result.Succeeded)
            {
                var loginUser = await _authService.GetUser(model.Email);
                var role = await _authService.GetRole(model.Email);
                if (role == "User")
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (role=="Admin")
                {
                    return RedirectToAction("AdminIndex", "Home");
                }
                
                return RedirectToAction("EmployeeIndex", "Home");
            }
            return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            await _authService.Logout();
            return RedirectToAction("Login");

        }
        [HttpGet]
        //public async Task<IActionResult> Register()
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var result = await _authService.Register(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View(model);
        }
        //public async Task<IActionResult> EmployeeRegister()
        public IActionResult EmployeeRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeRegister(EmployeeRegisterDto model)
        {
            var result = await _authService.EmployeeRegister(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View(model);
        }
        //public async Task<IActionResult> AdminRegister()
        public IActionResult AdminRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminRegister(AdminRegisterDto model)
        {
            var result = await _authService.AdminRegister(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View(model);
        }
        
    }
}
