using Cinema.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Components.MovieList
{
    public class MovieList:ViewComponent
    {
        private readonly IMovieService _movieService;
        public MovieList(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IViewComponentResult Invoke()
        {
            var list = _movieService.GetMovieList().Result;
            return View(list);
        }
    }
}
