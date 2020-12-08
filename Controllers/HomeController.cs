using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using My_movie_manager.Models;
using My_movie_manager.Services;
using Newtonsoft.Json;

namespace My_movie_manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [Route("MovieDetails/{imdbId}")]
        public async Task<ActionResult> MovieDetails(string imdbId)
        {
            //returning a single movie
            return View(await ApiService.GetMovieAsync("i", imdbId));
        }

        [Route("SearchForMovie/{movieName}")]
        public async Task<ActionResult> SearchForMovie([Bind("Title")] movieDetails movieName)
        {
            string tempTemp = movieName.Title;

            return View(await ApiService.GetMovieAsync("s", movieName.Title));
        }

    }
}
