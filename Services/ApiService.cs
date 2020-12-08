using My_movie_manager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace My_movie_manager.Services
{
    public class Apiservice
    {
        private static string Baseurl = "http://www.omdbapi.com/?apikey=f8fabbc";
        private static string urlUseId = "&i=";
        private static string urlUseSearch = "&s=";

        public static async Task<movieDetails> getMovieByIdAsync(string imdbId)
        {
            movieDetails singleMovie = new movieDetails();

            Baseurl += urlUseId + imdbId;

            //Baseurl = _configuration.GetConnectionString("movieApiUrl") + imdbId;

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(Baseurl);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var MovieResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    singleMovie = JsonConvert.DeserializeObject<movieDetails>(MovieResponse);

                }

                return singleMovie;
            }
        }

    }
}
