using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_movie_manager.Models;
using My_movie_manager.Services;

namespace My_movie_manager.Controllers
{
    public class MovieController : Controller
    {
        // GET: MovieController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovieController/Details/5
        [Route("movie/Detail/{imdbId}")]
        public async Task<ActionResult> Detail(string imdbId)
        {
            return View(await ApiService.GetMovieAsync("i", imdbId));
        }

        public async Task<IActionResult> List()
        {
            return View(await ApiService.GetMovieListDataAsync());
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        //Get id from web
        [HttpPost]
        [Route("movie/search")]
        public async Task<ActionResult> Search(string movieTitle)
        {
            //Is this bad?
            movieDetails getMovieDetail = await ApiService.GetMovieAsync("t", movieTitle);

            return Redirect(Url.RouteUrl(new { controller = "movie", action = "detail", getMovieDetail.imdbID}));
        }

    }
}
