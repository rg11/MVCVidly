using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using VidlyNew.Models;

namespace VidlyNew.Controllers.API
{
    /// <summary>
    /// 
    /// </summary>
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // api/Movies
        public IHttpActionResult GetMovies()
        {
            IEnumerable<Movie> movies = null;

            try
            {
                movies = _context.Movies.ToList();

                if (movies == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }


            return Ok(movies);
        }


        //  api/Movies/1
        public IHttpActionResult GetMovie(int Id)
        {
            Movie movieInDb = null;
   movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);

                if (movieInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
           


            return Ok(movieInDb);
        }

        [System.Web.Http.HttpPost]

        public IHttpActionResult CreateMovie(Movie newMovie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            return Created(Request.RequestUri + "/" + newMovie.Id, newMovie);
        }


        //Edit api/customers/1
        [System.Web.Http.HttpPut]
        public IHttpActionResult EditMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Movie movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            movieInDb.Name = movie.Name;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.QuantityInStock = movie.QuantityInStock;
            movieInDb.ReleasedDate = movie.ReleasedDate;

            _context.SaveChanges();

            return Ok(movieInDb);    
        }

        //Delete api/movies/1
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Movie movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(movieInDb);

            _context.SaveChanges();

            return Ok();

        }
    }
}
