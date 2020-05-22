using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface IOrderService
    {
        Order CreateOrder(CreateOrderOptions options, int aparam = 0);

        OrderProduct CreateOrderProduct(OrderProductOption option);



    }



}
