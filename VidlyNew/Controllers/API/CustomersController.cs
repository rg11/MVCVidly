using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyNew.Models;

namespace VidlyNew.Controllers.API
{
    public class CustomersController : ApiController
    {

        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // Get api/customers/1
        public Customer GetCustomer(int Id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
        }

        // Get api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            List<Customer> customers = _context.Customers.ToList();

            if (customers == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customers;
        }

        //POST api/customers
        [HttpPost]
        public Customer CreateCustomers(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }


        //Edit api/customers/1
        [HttpPut]
        public void EditCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

            if(customerInDb==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();

        }

        //Delete api/customers/1
        [HttpDelete]
        public HttpResponseMessage  DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            int isSaved = _context.SaveChanges();

            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
