using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TinyCrmDbContext()) {
                ICustomerService customerService = new CustomerService(
                    context);

                var results = customerService.SearchCustomers(
                    new SearchCustomerOptions()
                    {
                        CustomerId = 3
                    }).SingleOrDefault();
            }

            var orderOptions = new CreateOrderOptions();
            orderOptions.CustomerId = 5;
            orderOptions.ProductIds.Add("1312");
            orderOptions.ProductIds.Add("13112312312");
        }
    }
}
