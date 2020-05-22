using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public class ProductService : IProductService
    {

        private TinyCrmDbContext context_;

        public ProductService(TinyCrmDbContext context)
        {
            context_ = context;
        }


        public Product CreateProduct(CreateProductOptions prodOption)
        {
            try
            {
                Product product = new Product
                { ProductId= prodOption.ProductId,
                    Name = prodOption.Name,
                    Price = Decimal.Parse(prodOption.Price),
                    Description= prodOption.Description,
                };


                context_.Add(product);
                context_.SaveChanges();

                return product;
            }
            catch (Exception)
            { return null; }

        }

        public Product FindProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return context_.Set<Product>().ToList();
            
        }
    }
}
