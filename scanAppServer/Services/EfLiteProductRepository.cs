using System.Collections.Generic;
using System.Linq;
using ScanAppServer.Data;
using ScanAppServer.Interfaces;
using ScanAppServer.Model;

namespace ScanApp.Services
{
    public class EfLiteProductRepository : IProductRepository
    {

        public void Add(Product product)
        {
            using (var context = new ProductsContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }

        }

        public void Delete(Product product)
        {
            using (var context = new ProductsContext())
            {
                var productInDb = context.Products.FirstOrDefault(p => p.Id == product.Id);

                if (productInDb != null)
                {
                    context.Products.Remove(productInDb);
                    context.SaveChanges();
                }
            }
        }

        public List<Product> List()
        {
            using (var context = new ProductsContext())
            {
                return context.Products.ToList();
            }
        }

        public Product SearchByProductCode(string productCode)
        {
            using (var context = new ProductsContext())
            {
                return context.Products.FirstOrDefault(p => p.ProductCode == productCode);
            }
        }

        public void Update(Product product)
        {

            using (var context = new ProductsContext())
            {
                var productInDb = context.Products.FirstOrDefault(p => p.Id == product.Id);

                if (productInDb != null)
                {
                    context.Products.Remove(productInDb);
                    context.SaveChanges();
                }
            }

        }
    }
}