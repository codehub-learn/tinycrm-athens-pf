using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TinyCrm.Core.Data;
using TinyCrm.Core.Services;
using TinyCrm.Web.Models;
using TinyCrm.Core.Services.Options;
using TinyCrm.Core.Model;

namespace TinyCrm.Web.Controllers
{
    public class HomeController : Controller
    {
        private CustomerService customerService_;

        public HomeController()
        {
            customerService_ = new CustomerService(
                new TinyCrmDbContext());
        }

        public IActionResult Index()
        {
            var customers = customerService_.SearchCustomers(
                    new SearchCustomerOptions())
                .ToList();

            return View(customers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
