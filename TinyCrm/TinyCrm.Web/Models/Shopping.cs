using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCrm.Core.Model;

namespace TinyCrm.Web.Models
{
    public class Shopping
    {
        public List<Product> AvailableProducts { get; set; }
        public int  BasketId  { get; set; }
    }
}
