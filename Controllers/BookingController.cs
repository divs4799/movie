using MovieBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieBookingApp.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Book(int id)
        {
            foreach (var movie in MovieList.movieList)
            {
                if (movie.MovieID == id)
                {
                    Movie showMovie = movie;
                    ViewData["movieDetails"] = showMovie;
                }
            }
            foreach (var show in MovieList.showTimeList)
            {
                if (show.MovieID == id)
                {
                    ShowTime movieTime = show;
                    ViewData["showTime"] = movieTime;
                }
            }

            return View();
        }
        public ActionResult Confirm()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult book(Booking book) {

            //int showId = (int)ViewData["showid"];
            //int movieId = (int)ViewData["movieId"];
            int showId = ViewBag.showid;
            var movieId = ViewBag.movieid; 
            Booking book1 = new Booking(movieId,showId,book.NumberOfSeats,book.UserName,book.UserEmail);
            MovieList.BookingSeat(book.NumberOfSeats,movieId);
            MovieList.bookedList.Add(book);
            ViewBag.bookedShow = book;
            return RedirectToAction("Confirm");
        }
    }
}