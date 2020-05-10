using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using VidlyNew.Dtos;
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
            var moviesQuery = _context.Movies
                .Include(m=> m.Genre)
                .Where(m => m.QuantityInStock > 0);

            var moviesDto = moviesQuery
                            .ToList()
                            .Select(Mapper.Map<Movie, MovieDto>);

            if (moviesDto == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Ok(moviesDto);
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
                                                               

            return Ok(Mapper.Map<Movie,MovieDto>(movieInDb));
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Authorize(Roles = Constants.RoleNames.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var newMovie = Mapper.Map<MovieDto, Movie>(movie);

            _context.Movies.Add(newMovie);

            _context.SaveChanges();


            movie.Id = newMovie.Id;
                
            return Created(Request.RequestUri + "/" + movie.Id, movie);
        }


        //Edit api/customers/1
        [System.Web.Http.HttpPut]
        [System.Web.Http.Authorize(Roles = Constants.RoleNames.CanManageMovies)]
        public IHttpActionResult EditMovie(int id, MovieDto movieDto)
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

            movieDto.Id = movieInDb.Id;

            Mapper.Map<MovieDto,Movie>(movieDto, movieInDb);

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                //foreach (var entityValidationErrors in ex.EntityValidationErrors)
                //{
                //    foreach (var validationError in entityValidationErrors.ValidationErrors)
                //    {
                //        Console.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                //    }
                //}
                //OR

                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

            }

            return Ok(movieDto);    
        }

        //Delete api/movies/1
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Authorize(Roles = Constants.RoleNames.CanManageMovies)]
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
