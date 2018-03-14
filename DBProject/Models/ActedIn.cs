using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBProject.Models
{
    public class ActedIn
    {
        int Actor { get; set; } // matches to actor.ActorID
        int Movie { get; set; } // matches to movie.MovieID
        int Pay { get; set; } // Actor's pay for the movie
        bool Star { get; set; } // bool to show if they were the star of the movie
    }
}