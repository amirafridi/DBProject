using DBProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBProject.Services;

namespace DBProject.Controllers
{
    public class HomeController : Controller
    {
        public DbServices dbServices = new DbServices();
        

        public ActionResult Index()
        {
            return View();

        }

        [Route("AddMovie")]
        public ActionResult AddMovie ()
        {
            return View();
        }

        [Route("AddMovieConfirmation")]
        public ActionResult AddMovieConfirmation(Movie movie)
        {
            dbServices.AddMovie(movie);

            return View(movie);
        }

        [Route("AddActor")]
        public ActionResult AddActor ()
        {
            return View();
        }

        [Route("AddActorConfirmation")]
        public ActionResult AddActorConfirmation (Actor actor)
        {
            dbServices.AddActor(actor);

            return View(actor);
        }
        
        [Route("AddProducer")]
        public ActionResult AddProducer ()
        {
            return View();
        }

        [Route("AddProducerConfirmation")]
        public ActionResult AddProducerConfirmation (Producer producer)
        {
            dbServices.AddProducer(producer);

            return View(producer);
        }
        [Route("MovieDetails")]
        public ActionResult MovieDetails(string movie)
        {
            Movie model = dbServices.FetchMovieDetails(movie);
            return View(model);
        }
        

        

    }
}