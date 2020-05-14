using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Web.Controllers
{
    public class CustomerController : Controller
    {
        private TinyCrmDbContext dbContext_;
        private ICustomerService customerService_;

        public CustomerController()
        {
            dbContext_ = new TinyCrmDbContext();
            customerService_ = new CustomerService(dbContext_);
        }

        public IActionResult Index()
        {
            var customerList = customerService_ 
                .SearchCustomers(new SearchCustomerOptions())
                .ToList();

            return Json(customerList);
        }

        public IActionResult Search()
        {

        }

        //400 Bad Request
        //403 Forbidden
        //404 Not Found
        // 500 Internal Server Error
        public IActionResult GetById(int? id)
        {
            if (id == null) {
                return BadRequest();
            }

            var customer = customerService_
                .SearchCustomers(
                    new SearchCustomerOptions() {
                        CustomerId = id
                    }).SingleOrDefault();

            if (customer == null) {
                return NotFound();
            }

            return Json(customer);
        }
    }
}