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

namespace TinyCrm.Web.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ICustomerService customerService_;

        public HomeController(ILogger<HomeController> logger, ICustomerService customerService)
        {
            _logger = logger;
            customerService_ = customerService;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("Customers")]
        public IActionResult Customers()
        {
            CustomersModel customersModel = new CustomersModel
            {      Customers = customerService_.GetAll() .ToList()
        };

            

            return View(customersModel);
        }

        
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
