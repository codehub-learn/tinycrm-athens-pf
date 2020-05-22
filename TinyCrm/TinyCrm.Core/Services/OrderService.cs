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


            return order;
        }

        OrderProduct CreateOrderProduct(OrderProductOption option)
        {
            OrderProduct orderProduct = new OrderProduct {
             OrderId = option.OrderId,  ProductId =option.ProductId  
            };
            context_.Add(orderProduct);
            context_.SaveChanges();
            return orderProduct;

        }

        OrderProduct IOrderService.CreateOrderProduct(OrderProductOption option)
        {

            Product product = context_.Set<Product>().Find(option.ProductId);
                

            OrderProduct basketProduct = new OrderProduct
            { OrderId= option.OrderId,
              Product=product
            };

            context_.Set<OrderProduct> ().Add(basketProduct)    ;
            context_.SaveChanges();
            return basketProduct;



        }
    }
}
