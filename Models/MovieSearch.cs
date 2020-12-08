using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace My_movie_manager.Models
{
    public class MovieSearch
    {
        [Table("Search")]
        public class Search
        {
            [Key]
            public string imdbID { get; set; }
            public string Title { get; set; }
            public string Year { get; set; }

            public string Type { get; set; }
            public string Poster { get; set; }
        }

        public class Root
        {
            public List<Search> Search { get; set; }
            public string totalResults { get; set; }
            public string Response { get; set; }
        }

    }
}
