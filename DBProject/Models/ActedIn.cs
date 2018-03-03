using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBProject.Models
{
    public class ActedIn
    {
        string Actor { get; set; } // matches to actor.actorname
        string Movie { get; set; } // matches to movie.moviename
        string Producer { get; set; } // matchest to producer.producername
        int Pay { get; set; } // Actor's pay for the movie
    }
}