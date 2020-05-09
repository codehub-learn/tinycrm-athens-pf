using System.Collections.Generic;

namespace TinyCrm
{
    public class CreateOrderOptions
    {
        public int CustomerId { get; set; }
        public List<string> ProductIds { get; set; }

        public CreateOrderOptions()
        {
            ProductIds = new List<string>();
        }
    }
}
