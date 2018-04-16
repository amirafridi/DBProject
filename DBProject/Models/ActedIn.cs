using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBProject.Models
{
    public class ActedIn
    {
        public string Actor { get; set; } // matches to actor.ActorID
        public string Movie { get; set; } // matches to movie.MovieID
        public string CharName { get; set; } // actors name in the movie
        public int Pay { get; set; } // Actor's pay for the movie
    }
}