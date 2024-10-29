using Business_Objects;
using MyStore_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo productRepo;
        public ProductService()
        {
            productRepo = new ProductRepo();
        }
        public bool CreateProduct(Product product)
        {
            return productRepo.CreateProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return productRepo.DeleteProduct(id);
        }

        public Product GetProductById(int id)
        {
            return productRepo.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            return productRepo.GetProducts();
        }

        public bool UpdateProduct(Product product)
        {
            return productRepo.UpdateProduct(product);
        }
    }
}
