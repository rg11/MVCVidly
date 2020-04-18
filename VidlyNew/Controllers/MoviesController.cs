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
            return Content("id "+id);
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
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(string Id)
        {
            Movie movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id.ToString() == Id);
            return View(movie);
        }
       
    }
}