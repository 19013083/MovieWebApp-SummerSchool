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
        
 
        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> MovieList()
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
