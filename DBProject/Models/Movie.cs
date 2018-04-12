using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBProject.Models
{
    public class Movie
    {

        public string Title { get; set; } // Title of the movie
        public string Producer { get; set; } // Name of the producer
        public DateTime ReleaseDate { get; set; } // release date of the movie
        public DateTime RunTime { get; set; } // runtime of the movie
        public int Budget { get; set; } // budget of the movie
        public int Gross { get; set; } // gross income of the movie
        public int Rating { get; set; } // rating between 1-10

        
    }
}