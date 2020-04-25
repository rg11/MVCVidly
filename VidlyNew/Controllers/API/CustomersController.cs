using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyNew.Dtos;
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
        public CustomerDto GetCustomer(int Id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

           
            return Mapper.Map<Customer,CustomerDto>(customer);
        }

        // Get api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = _context.Customers.ToList().Select(Mapper.Map <Customer,CustomerDto>);

            if (customers == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customers;
        }

        //POST api/customers
        [HttpPost]
        public CustomerDto CreateCustomers(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);

            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
        }


        //Edit api/customers/1
        [HttpPut]
        public void EditCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customerDto.Id);

            if(customerInDb==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDb);

            
            _context.SaveChanges();

        }

        //Delete api/customers/1
        [HttpDelete]
        public void  DeleteCustomer(int id)
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

            _context.SaveChanges();
                                                
        }
    }
}
