using Business_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Services
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public Product GetProductById(int id);
        public bool CreateProduct(Product product);
        public bool UpdateProduct(Product product);
        public bool DeleteProduct(int id);
    }
}
