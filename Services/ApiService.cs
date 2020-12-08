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
    public class ApiService
    {
        private static string Baseurl = "http://www.omdbapi.com/?apikey=f8fabbc";

        public static async Task<movieDetails> GetMovieAsync(string action, string actionInput)
        {
            movieDetails singleMovie = new movieDetails();

            Baseurl += "&"+action+"=" + actionInput;

            //Baseurl = _configuration.GetConnectionString("movieApiUrl") + urlUseId + imdbId;

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

        //Get list of movies with their details
        public async Task<List<movieDetails>> GetMovieListDataAsync()
        {
            List<movieDetails> MovieData = new List<movieDetails>();
            for (int i = 0; i < GetListOfMovies().Count; i++)
            {
                MovieData.Add(await GetMovieAsync("i", GetListOfMovies().ElementAt(i)));
            }

            return MovieData;
        }

        private List<string> GetListOfMovies()
        {
            List<string> MovieList = new List<string>();
            MovieList.Add("tt0114709");
            MovieList.Add("tt0101414");
            MovieList.Add("tt1691926");
            MovieList.Add("tt4263482");
            MovieList.Add("tt1375666");
            MovieList.Add("tt5052448");
            MovieList.Add("tt5281134");
            MovieList.Add("tt0335266");
            MovieList.Add("tt0499549");
            MovieList.Add("tt0137523");

            return MovieList;
        }

    }
}
