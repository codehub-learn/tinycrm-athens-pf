using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface IProductService
    {
        Product CreateProduct(CreateProductOptions prodOption);
        Product FindProductById(int id);
        List<Product> GetAll();

    }
}
