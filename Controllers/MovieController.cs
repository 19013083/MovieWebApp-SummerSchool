using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_movie_manager.Models;
using My_movie_manager.Models.MovieManagerModel;
using My_movie_manager.Services;

namespace My_movie_manager.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieManagerModelContext _context;

        public MovieController(MovieManagerModelContext context)
        {
            _context = context;
        }

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


        //Trying to return personal list
        public async Task<IActionResult> ListV2()
        {
            int tempUserId;

            try
            {
                tempUserId = (int)HttpContext.Session.GetInt32("currentUser");

            }
            catch (Exception)
            {
                return RedirectToAction("login", "users");
            }

            var getUserFavData = _context.FavouriteUserMovies.Where(f => f.UserId.Equals(tempUserId));

            var userFavList = await getUserFavData.ToListAsync();

            //return RedirectToAction("list");
            return View(await ApiService.GetMovieListDataAsyncVersion2(userFavList.ToList()));
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

        public async Task<IActionResult> AddToFav(string imdbId)
        {
            if (HttpContext.Session.GetInt32("currentUser") == null)
            {
                return RedirectToAction("login", "users");
            }

            FavouriteUserMovie newEntry = new FavouriteUserMovie();
            newEntry.MovieId = imdbId;
            newEntry.UserId = HttpContext.Session.GetInt32("currentUser");

            try
            {
                _context.Add(newEntry);
                await _context.SaveChangesAsync();

                return RedirectToAction("index", "FavouriteUserMovies");
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
    }
}
