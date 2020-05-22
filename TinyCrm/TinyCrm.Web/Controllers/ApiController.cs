using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : Controller
    {
         
        private ICustomerService customerService_;
        private IOrderService orderService_;
        private IProductService productService_;

        public ApiController(ICustomerService customerService, IOrderService orderService, IProductService productService)
        {
            customerService_ = customerService;
            orderService_ = orderService;
            productService_ = productService;
        }


        [HttpPost("createProduct")]
        public IActionResult CreateProduct([FromBody] CreateProductOptions options)
        {
            var result = productService_.CreateProduct(options);

            if (result == null)
            {
                return BadRequest();
            }

            return Json(result);
        }



        [HttpPost("createCustomer")]
        public IActionResult Create([FromBody] CreateCustomerOptions options)
        {
            var result = customerService_.CreateCustomer(options);

            if (result == null) {
                return BadRequest();
            }

            return Json(result);
        }

        [HttpPost("createOrder")]
        public IActionResult CreateOrder([FromBody] CreateOrderOptions options)
        {
            return Json(orderService_.CreateOrder(options));
        }



        [HttpPost("addOrderProduct")]
         public IActionResult AdddOrderProduct(
            [FromBody] OrderProductOption options)
        {
            OrderProduct ordPrd = orderService_.CreateOrderProduct(options);

            return Json(ordPrd);
        }


        [HttpGet]
        public IActionResult Index()
        {
            var customerList = customerService_
                .SearchCustomers(new SearchCustomerOptions())
                .ToList();

            return Json(customerList);
        }

        [HttpGet("{id}")]
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

        [HttpPatch("{id}")]
        public IActionResult UpdateCustomer(int id)
        {
            return Ok();
        }
    }
}