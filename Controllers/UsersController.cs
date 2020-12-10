using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My_movie_manager.Models.MovieManagerModel;
using My_movie_manager.Services;

namespace My_movie_manager.Controllers
{
    public class UsersController : Controller
    {
        private readonly MovieManagerModelContext _context;

        public UsersController(MovieManagerModelContext context)
        {
            _context = context;
        }

        // GET: Users
        public string Index()
        {
            return "Nothing to view here";
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details()
        {
            int? id = HttpContext.Session.GetInt32("currentUser");

            if (id == null)
            {
                return RedirectToAction("login");
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return RedirectToAction("login");
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Email,Firstname,Surname,Password,FavoriteMovie,DateOfBirth")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Security.ComputeSha256Hash(user.Password);
                _context.Add(user);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetInt32("currentUser", user.UserId);
                return RedirectToAction("index", "home");
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.Password = null;
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Email,Firstname,Surname,Password,FavoriteMovie,DateOfBirth")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("details");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        //Return login page
        public IActionResult Login()
        {
            return View();
        }

        //Get login info
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string inUserEmail, string inPassword)
        {
            if (ModelState.IsValid)
            {
                string hashPassword = Security.ComputeSha256Hash(inPassword);

                User getUser = await _context.Users
                    .FirstOrDefaultAsync(m => m.Email.Equals(inUserEmail) & m.Password.Equals(hashPassword));

                if (getUser == null)
                {
                    ViewBag.userNotFound = "Not found in database, please check your details.";
                    return Login();
                }

                //success, sending user to home
                HttpContext.Session.SetInt32("currentUser", getUser.UserId);//storing PK of user
                return RedirectToAction("index", "home");

            }
            return View();
        }

        public IActionResult Signout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "home");
        }
    }
}
