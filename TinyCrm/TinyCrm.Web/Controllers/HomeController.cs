using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using System.Linq;

using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services;
using TinyCrm.Core.Services.Options;
using TinyCrm.Web.Models;

namespace TinyCrm.Web.Controllers
{
    public class HomeController : Controller
    {
        private CustomerService customerService_;
        private TinyCrmDbContext context;

        public HomeController()
        {
            context = new TinyCrmDbContext();
            customerService_ = new CustomerService(
               context);
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel()
            {
                Customers = customerService_.SearchCustomers(
                        new SearchCustomerOptions())
                    .ToList(), 
                Products = context.Set<Product>()
                    .ToList()
            };

            return View(viewModel);
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
