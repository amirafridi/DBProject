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
            bool flag = dbServices.AddMovie(movie);
            if (flag)
            {
                return View(movie);
            } else
            {
                Producer producer = new Producer
                {
                    Name = movie.Producer
                };
                return View("AddProducer", producer);
            }
            
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
            model.Actors = dbServices.FetchActorsForMovie(movie);
            return View(model);
        }
        [Route("ActorDetails")]
        public ActionResult ActorDetails(string actor)
        {
            Actor model = dbServices.FetchActorDetails(actor);
            model.Movies = dbServices.FetchMoviesForActor(actor);
            return View(model);
        }
        [Route("ProducerDetails")]
        public ActionResult ProducerDetails(string producer)
        {
            Producer model = dbServices.FetchProducerDetails(producer);
            model.Movies = dbServices.FetchMoviesForProducer(producer);
            return View(model);
        }
        [Route("Movies")]
        public ActionResult Movies (string sortby= "ReleaseDate")
        {
            List<Movie> movies = dbServices.FetchAllMovies(sortby);
            return View(movies);
        }
        [Route("Actors")]
        public ActionResult Actors (string sortby="Name")
        {
            List<Actor> actors = dbServices.FetchAllActors(sortby);
            return View(actors);
        }

        [Route("Producers")]
        public ActionResult Producers (string sortby="Name")
        {
            List<Producer> producers = dbServices.FetchAllProducers(sortby);
            return View(producers);
        }

        [Route("AddActorToMovie")]
        public ActionResult AddActorToMovie(string movie)
        {
            ActedIn actedIn = new ActedIn
            {
                Movie = movie
            };
            return View(actedIn);
        }

        [Route("AddActorToMovieConfirmation")]
        public ActionResult AddActorToMovieConfirmation(ActedIn actedIn)
        {
            bool flag = dbServices.AddActorToMovie(actedIn);
            if(!flag)
            {
                Actor actor = new Actor
                {
                    Name = actedIn.Actor
                };
                return View("AddActor", actor);
            }
            else
            {
                return View(actedIn);
            }
        }

        [Route("AddMovieToActor")]
        public ActionResult AddMovieToActor(string actor)
        {
            ActedIn actedIn = new ActedIn
            {
                Actor = actor
            };
            return View(actedIn);
        }

        [Route("AddMovieToActorConfirmation")]
        public ActionResult AddMovieToActorConfirmation(ActedIn actedIn)
        {
            bool flag = dbServices.AddMovieToActor(actedIn);
            if (!flag)
            {
                Movie movie = new Movie
                {
                    Title = actedIn.Movie
                };
                return View("AddMovie", movie);
            }
            else
            {
                return View(actedIn);
            }
        }

        [Route("AddMovieToProducer")]
        public ActionResult AddMovieToProducer (string producer)
        {
            Movie movie = new Movie
            {
                Producer = producer
            };

            return View("AddMovie", movie);
        }




    }
}