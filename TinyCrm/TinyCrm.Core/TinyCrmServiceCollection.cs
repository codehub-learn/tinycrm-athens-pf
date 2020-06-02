using Microsoft.Extensions.DependencyInjection;

using TinyCrm.Core.Data;
using TinyCrm.Core.Services;

namespace TinyCrm.Core
{
    public static class TinyCrmServiceCollection
    {
        public static void AddTinyCrmServices(this IServiceCollection services)
        {
            services.AddDbContext<TinyCrmDbContext>();
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
