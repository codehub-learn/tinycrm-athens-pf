using System.Linq;

using Xunit;

using TinyCrm.Core.Services;
using TinyCrm.Core.Services.Options;
using Microsoft.Extensions.DependencyInjection;

namespace TinyCrm.Tests
{
    public class CustomerServiceTests : IClassFixture<TinyCrmFixture>
    {
        private ICustomerService customers_;

        public CustomerServiceTests(TinyCrmFixture fixture)
        {
            customers_ = fixture.Provider.GetService<ICustomerService>();
        }

        [Fact]
        public void CreateCustomer_Fail_Null_Options()
        {
            var result = customers_.CreateCustomer(null);
            Assert.NotNull(result);

            Assert.Equal(Core.StatusCode.BadRequest, result.ErrorCode);
        }

        [Fact]
        public void CreateCustomer_Fail_Null_VatNumber()
        {
            var result = customers_.CreateCustomer(
                new CreateCustomerOptions());
            Assert.NotNull(result);
            Assert.Equal(Core.StatusCode.BadRequest, result.ErrorCode);

            result = customers_.CreateCustomer(
                new CreateCustomerOptions()
                {
                    Vatnumber = "       "
                });
            Assert.NotNull(result);
            Assert.Equal(Core.StatusCode.BadRequest, result.ErrorCode);
        }

        [Fact]
        public void CreateCustomer_Success()
        {
            var options = new CreateCustomerOptions()
            {
                Firstname = "Dimitris",
                Lastname = "Pnevmatikos",
                Vatnumber = "123456789"
            };

            var result = customers_.CreateCustomer(options);
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.NotNull(result.Data);

            var customer = customers_.SearchCustomers(
                new SearchCustomerOptions()
                {
                    CustomerId = result.Data.CustomerId
                }).SingleOrDefault();
            Assert.NotNull(customer);
            Assert.Equal(options.Firstname, customer.Firstname);
            Assert.Equal(options.Vatnumber, customer.VatNumber);
            Assert.Equal(0, customer.TotalGross);
        }
    }
}
