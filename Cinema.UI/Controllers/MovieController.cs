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
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Index()
        {
            var movieList = await _movieService.GetMovieList();
            return View(movieList);
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await GetMovieById(id);
            var movieConvertVM = Convert(movie);
            return View(movieConvertVM);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var movie = await GetMovieById(id);
            var movieConvertVM = Convert(movie);
            return View(movieConvertVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(MovieConvertVM movieConvertVM)
        {
            if (ModelState.IsValid)
            {
                var movie = _mapper.Map<Movie>(movieConvertVM);
                await _movieService.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movieConvertVM);
        }
        [HttpGet]
        /*public async Task<IActionResult> Create()*/
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieVM movieVM)
        {
            if (ModelState.IsValid)
            {
                var movie = _mapper.Map<Movie>(movieVM);
                await _movieService.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movieVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _movieService.GetMovieById(id);
        }
        public MovieConvertVM Convert(Movie movie)
        {
            return _mapper.Map<MovieConvertVM>(movie);
        }
    }
}
