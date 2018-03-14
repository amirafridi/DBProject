using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBProject.Models
{
    public class ActedIn
    {
        string Actor { get; set; } // matches to actor.ActorID
        string Movie { get; set; } // matches to movie.MovieID
        int Pay { get; set; } // Actor's pay for the movie
    }
}