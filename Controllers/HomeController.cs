﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using My_movie_manager.Models;
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

        //Hosted web API REST Service base url  
        string Baseurl = "http://www.omdbapi.com/?i=tt3896198&apikey=f8fabbc";
        public async Task<ActionResult> MovieDetails()
        {
            List<movieDetails> singleMovie = new List<movieDetails>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Employee/GetAllEmployees");

                //Checking the response is successful or not which is sent using HttpClient  
                //if (Res.IsSuccessStatusCode)
                //{
                //    //Storing the response details recieved from web api   
                //    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                //    //Deserializing the response recieved from web api and storing into the Employee list  
                //    singleMovie = JsonConvert.DeserializeObject<List<movieDetails>>(EmpResponse);

                //}
                //returning the employee list to view  
                return View(singleMovie);
            }
        }
    }
}