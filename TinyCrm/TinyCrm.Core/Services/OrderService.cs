using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public class OrderService : IOrderService
    {
        private TinyCrmDbContext context_;
        private ICustomerService customerService_;
        public OrderService(TinyCrmDbContext context, ICustomerService customerService)
        {
            context_ = context;
            customerService_ = customerService;
        }

        public Order CreateOrder(CreateOrderOptions options, int aparam = 0)
        {
            Order order= new Order { Created= DateTime.Now  };

            context_.Add(order);
            context_.SaveChanges();
            return order;

        }
    }
}
