using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface ICustomerService
    {
        IQueryable<Customer> SearchCustomers(
            SearchCustomerOptions options);
        IQueryable<Customer> GetAll();
        Customer CreateCustomer(
            CreateCustomerOptions options);

        Customer GetCustomer(
            int id);
    }
}
