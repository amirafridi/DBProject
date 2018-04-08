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
            //dbServices.AddMovie(movie);

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
            return View(actor);
        }

        

    }
}