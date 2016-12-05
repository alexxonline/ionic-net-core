using System.Collections.Generic;
using ScanAppServer.Model;

namespace ScanAppServer.Interfaces {
    public interface IProductRepository  {
        void Add(Product product);
        void Update(Product product);
        List<Product> List();
        Product SearchByProductCode(string productCode); 
        void Delete(Product product);
    }
}