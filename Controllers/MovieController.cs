using MVCDEMO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDEMO2.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View("Index", "MovieLayout");
        }

     


        public ActionResult MoviePage(Movie m, string update)
        {
            MovieUtilities mu = new MovieUtilities();
            ViewBag.Message = "Single Move Page";

            if (update == "update")
            {
               
                mu.updateMovie(m);
                m.IsEditable = false;
            }
            else
            {
                
                m = mu.getMovieByID(m.Id);
            }
            return View("MoviePage", "MovieLayout", m);
        }


        public ActionResult AllMovies(Movies m, string update)
        {
            MovieUtilities wu = new MovieUtilities();


            if (update == "update")
            {

                Movie movie = m.Items[m.EditIndex];
                wu.updateMovie(movie);
                movie.IsEditable = false;
            }

            
            ViewBag.Message = "All movies.";
           
            m = wu.getAllMovies();

            
            return View("AllMovies", "MovieLayout", m);

        }
        public ActionResult MoviesEdit(int? id, Movies movies)
        {

            int id2 = id ?? default(int);

            MovieUtilities mu = new MovieUtilities();

            movies = mu.getAllMovies();
            movies.EditIndex = mu.setMovieToEditMode(movies.Items, id2);

            ViewBag.Message = "All movies.";

            return View("AllMovies", "MovieLayout" ,movies);

        }
        public ActionResult MovieEdit(int? id, Movie movie)
        {

            int id2 = id ?? default(int);

            MovieUtilities mu = new MovieUtilities();
            movie = mu.getMovieByID(movie.Id);


            movie.IsEditable = true;

            ViewBag.Message = "This is a simple movie editor";

            return View("MoviePage", "MovieLayout", movie);

        }

        public ActionResult NewMovie(string add, Movie m)
        {

            

            MovieUtilities mu = new MovieUtilities();
            if (add == "add")
            {
                mu.addMovie(m);


            }


            return View("NewMovie", "MovieLayout", m);

        }

        public ActionResult MovieDelete(int? id)
        {

            int id2 = id ?? default(int);

            MovieUtilities mu = new MovieUtilities();
            mu.MovieDelete(id2);


            return RedirectToAction("AllMovies");

        }



    }
}
    
