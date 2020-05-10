using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using VidlyNew.ViewModels;


namespace VidlyNew.Controllers
{
    [RoutePrefix("Movies")]
    public class MoviesController: Controller
    {

        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new Models.ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        ///Passing Data to the View can be possible three ways:
        ///Directly passing the model to the view 
        ///Using ViewData Dictionary
        ///Using ViewBag Dynamic type        
        /// <summary>
        /// Example of Action Results
        /// </summary>
        /// <returns></returns>
        public ActionResult Random()
        {

            ///Types of ActionResults:
            // return Content("Hello");
            //return HttpNotFound();
            // return new EmptyResult();
            //return RedirectToAction("Index", "home");

            var movie = new Movie { Name = "Shrek!" };
            List<Customer> customers = new List<Customer>
            {
                new Customer {Name="Customer1" },
                new Customer { Name="Customer2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            
           
            return View(viewModel);


            
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit Movie";

            Movie  movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            MovieFormViewModel movieFormVM = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieFormView", movieFormVM);
        }

        /// <summary>
        /// Example of Action Parameters
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public ActionResult Sort(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1; 
            if (string.IsNullOrEmpty(sortBy))
                sortBy = "Name";
                
            return Content("PageIndex : " + pageIndex + " and Sort By: " + sortBy);
        }

        /// <summary>
        /// Example of Attribute routing which came with ASP.net MVC 5
        /// </summary>

        [Route("Movies/Released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {

            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            // var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole(Constants.RoleNames.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int Id)
        {
            Movie movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            
            return View(movie);
        }

        public ActionResult New()
        {
            ViewBag.Title = "New Movie";

            MovieFormViewModel movieFormVM = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieFormView", movieFormVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                MovieFormViewModel movieVM = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                
                return View("MovieFormView", movieVM);
            }

            if(movie.Id==0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                Movie movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleasedDate = movie.ReleasedDate;
                movieInDb.QuantityInStock = movie.QuantityInStock;

                return RedirectToAction("Index", "Movies");
            }

            _context.SaveChanges();

            return View();
        }
    }
}