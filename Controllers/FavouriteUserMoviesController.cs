using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My_movie_manager.Models.MovieManagerModel;

namespace My_movie_manager.Controllers
{
    public class FavouriteUserMoviesController : Controller
    {
        private readonly MovieManagerModelContext _context;

        public FavouriteUserMoviesController(MovieManagerModelContext context)
        {
            _context = context;
        }

        // GET: FavouriteUserMovies
        public async Task<IActionResult> Index()
        {
            var movieManagerModelContext = _context.FavouriteUserMovies.Include(f => f.User);
            return View(await movieManagerModelContext.ToListAsync());
        }

        // GET: FavouriteUserMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favouriteUserMovie = await _context.FavouriteUserMovies
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favouriteUserMovie == null)
            {
                return NotFound();
            }

            return View(favouriteUserMovie);
        }

        // GET: FavouriteUserMovies/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: FavouriteUserMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,MovieId")] FavouriteUserMovie favouriteUserMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favouriteUserMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", favouriteUserMovie.UserId);
            return View(favouriteUserMovie);
        }

        // GET: FavouriteUserMovies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favouriteUserMovie = await _context.FavouriteUserMovies.FindAsync(id);
            if (favouriteUserMovie == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", favouriteUserMovie.UserId);
            return View(favouriteUserMovie);
        }

        // POST: FavouriteUserMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,MovieId")] FavouriteUserMovie favouriteUserMovie)
        {
            if (id != favouriteUserMovie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favouriteUserMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavouriteUserMovieExists(favouriteUserMovie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", favouriteUserMovie.UserId);
            return View(favouriteUserMovie);
        }

        // GET: FavouriteUserMovies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favouriteUserMovie = await _context.FavouriteUserMovies
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favouriteUserMovie == null)
            {
                return NotFound();
            }

            return View(favouriteUserMovie);
        }

        // POST: FavouriteUserMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favouriteUserMovie = await _context.FavouriteUserMovies.FindAsync(id);
            _context.FavouriteUserMovies.Remove(favouriteUserMovie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavouriteUserMovieExists(int id)
        {
            return _context.FavouriteUserMovies.Any(e => e.Id == id);
        }
    }
}
