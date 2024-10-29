using Business_Objects;
using MyStore_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Repositories
{
    public class ProductRepo : IProductRepo
    {
        public bool CreateProduct(Product product)
        {
            return ProductDAO.Instance.CreateProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return ProductDAO.Instance.DeleteProduct(id);
        }

        public Product GetProductById(int id)
        {
            return ProductDAO.Instance.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            return ProductDAO.Instance.GetProducts();
        }

        public bool UpdateProduct(Product product)
        {
            return ProductDAO.Instance.UpdateProoduct(product);
        }
    }
}
