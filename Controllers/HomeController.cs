using MVCDEMO2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCDEMO2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            ViewBag.Message = "This is a test.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your Contact Page";
            return View();
        }

        public ActionResult MoviePage(Movie m, string update)
        {
            ViewBag.Message = "Single Move Page";

            if (update == "update")
            {
                Movie me2 = m;
                m.IsEditable = false;
            }
            else
            {
                MovieUtilities mu = new MovieUtilities();
                m = mu.getMovieByID(2);
            }
            return View(m);
        }


        public ActionResult AllMovies(Movies m, string update)
        {
            if (update == "update")
            {
                Movie movie = m.Items[m.EditIndex];
                movie.IsEditable = false;
            }

            MovieUtilities wu = new MovieUtilities();
            ViewBag.Message = "All movies.";

            m = wu.getAllMovies();

            return View(m);

        }
        public ActionResult MoviesEdit(int? id, Movies movies)
        {

            int id2 = id ?? default(int);

            MovieUtilities mu = new MovieUtilities();

            movies = mu.getAllMovies();
            movies.EditIndex = mu.setMovieToEditMode(movies.Items, id2);

            ViewBag.Message = "All movies.";

            return View("AllMovies", movies);

        }
        public ActionResult MovieEdit(int? id, Movie movie)
        {

            int id2 = id ?? default(int);

            MovieUtilities mu = new MovieUtilities();
            movie = mu.getMovieByID(movie.Id);


            movie.IsEditable = true;

            ViewBag.Message = "This is a simple movie editor";

            return View("MoviePage", movie);

        }

    }
}
    


