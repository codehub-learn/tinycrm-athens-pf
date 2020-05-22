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
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private ICustomerService customerService_;
        private IOrderService orderService_;
        private IProductService productService_;
        private TinyCrmDbContext context_;

        public HomeController(ICustomerService customerService, IOrderService orderService, IProductService productService,
            TinyCrmDbContext context)
        {
            customerService_ = customerService;
            orderService_ = orderService;
            productService_ = productService;
            context_ = context;
        }

        [HttpGet("")]
        public IActionResult Home()
        {
            return View("Index");
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
            {      
                Customers = customerService_.GetAll() .ToList()
            };
            return View(customersModel);
        }

        [HttpGet("Products")]
        public IActionResult Products()
        {
            ProductsModel productsModel = new ProductsModel
            {
                Products = productService_.GetAll().ToList()
            };
            return View(productsModel);
        }

        //Privacy
        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }



        //create customer
        [HttpGet("AddCustomer")]
        public IActionResult CreateCustomer()
        {
            return View("AddCustomer");
        }

        //products
        [HttpGet("AddProduct")]
        public IActionResult CreateProduct()
        {
            return View("AddProduct");
        }


        //buy


        [HttpGet("Shopping")]
        public IActionResult Shopping()
        {
            int  customerId = 3;
            Customer customer = customerService_.GetCustomer(customerId);

            Order basket = new Order { Created=DateTime.Now,  DeliveryAddress= customer.Email };
            customer.Orders.Add(basket);
            context_.SaveChanges();

          

            Shopping shopping = new Models.Shopping
            {
               AvailableProducts = productService_.GetAll(),
               BasketId = basket.OrderId
            };

            return View(shopping);
        }






        [HttpGet("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
