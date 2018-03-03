﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBProject.Models
{
    public class Movie
    {
        string Title { get; set; } // Title of the movie. PK
        string Producer { get; set; } // Name of the producer
        DateTime ReleaseDate { get; set; } // release date of the movie
        DateTime RunTime { get; set; } // runtime of the movie
        int Budget { get; set; } // budget of the movie
        int Gross { get; set; } // gross income of the movie
        
    }
}