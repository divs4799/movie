using Microsoft.Ajax.Utilities;
using MovieBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieBookingApp.Controllers
{
    public class MovieController : Controller
    {
          // GET: Movie
        public ActionResult Index()

        {
            MovieList.AddMovies();
            Session["movieList"] = MovieList.movieList;
            Session["showtimes"] = MovieList.showTimeList;
            return View();
        }
        //public ActionResult Details()
        //{
           
        //    return RedirectToAction("Index");
        //}
        public ActionResult Details(int id)
        {
           
            foreach (var movie in MovieList.movieList)
            {
                if (movie.MovieID == id) {
                    Movie showMovie = movie;
                    ViewData["movieDetails"] = showMovie;
                }
            }
            foreach (var show in MovieList.showTimeList) {
                if (show.MovieID == id) {
                    ShowTime movieTime = show;
                    ViewData["showTime"] = movieTime;
                }
            }
           
           
            
            return View();
        }
        public ActionResult AddMovie()
        {
            return View();
        }

       

        [HttpPost]
        public ActionResult createMovie(Movie movie) {

            List<Movie> movieList = (List<Movie>)Session["movieList"];
           
            Movie tempMovie = new Movie(movie.Title, movie.Description, movie.Genre, movie.Duration, movie.ReleaseDate);
            int movieId = tempMovie.MovieID;
            ShowTime tempShow = new ShowTime(movieId,movie.time);
            movieList.Add(tempMovie);
            Session["movieList"] = movieList;
          
            return RedirectToAction("Index");

        }
    }
}