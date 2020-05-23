using System.Linq;

using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface ICustomerService
    {
        IQueryable<Customer> SearchCustomers(
            SearchCustomerOptions options);

        Result<Customer> CreateCustomer(
            CreateCustomerOptions options);

        bool UpdateCustomer(int customerId,
            UpdateCustomerOptions options);
    }
}
