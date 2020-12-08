﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_movie_manager.Services;

namespace My_movie_manager.Controllers
{
    public class MovieController : Controller
    {
        string Baseurl = "http://www.omdbapi.com/?apikey=f8fabbc" + "&s=";

        //Search for a movie
        [Route("SearchMovie/{movieName}")]
        public async Task<ActionResult> SearchMovie(string movieName)
        {
            return View(await ApiService.GetMovieAsync("t", movieName));
        }
        
        // GET: MovieController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovieController/Details/5
        [Route("movie/DetailsDetails/{imdbId}")]
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
    }
}
