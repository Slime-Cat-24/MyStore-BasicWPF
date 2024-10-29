using Business_Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_DAOs
{
    public class ProductDAO
    {
        private MyStoreContext _context;
        private static ProductDAO instance;

        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }
        public ProductDAO()
        {
            _context = new MyStoreContext();
        }
        public List<Product> GetProducts()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }
        public Product GetProductById(int id)
        {
            return _context.Products.Include(p => p.Category).SingleOrDefault(p => p.ProductId == id);
        }
        public bool CreateProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteProduct(int id)
        {
            try
            {
                var product = GetProductById(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateProoduct(Product product)
        {
            try
            {
                var productToUpdate = GetProductById(product.ProductId);
                if (productToUpdate != null)
                {
                    _context.Entry<Product>(productToUpdate).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
