using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyNew.Models;
using VidlyNew.ViewModels;

namespace VidlyNew.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer

        public ActionResult Index()
        {
            IEnumerable<Customer> customers = GetCustomers();

            return View(customers);
        }

        private static IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id=1, Name="Customer1"},
                new Customer {Id=2, Name="Customer2"}
            };

        }

        public ActionResult Details(string Id)
        {
            Customer customer = GetCustomers().FirstOrDefault(p => p.Id.ToString() == Id);
            return View(customer);
        }
    }
}