using Business_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyStore_DAOs
{
    public class CategoryDAO
    {
        private MyStoreContext _context;
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDAO();
                }
                return instance;
            }
        }
        private CategoryDAO()
        {
            _context = new MyStoreContext();
        }
        public List<Category> GetCategories()
        {
            return _context.Categories.Include(c => c.Products).ToList();
        }
        public Category GetCategoryById(int id)
        {
            return _context.Categories.Include(c => c.Products).SingleOrDefault(c => c.CategoryId == id);
        }
        public bool CreateCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteCategory(int id)
        {
            try
            {
                var category = GetCategoryById(id);
                if (category != null)
                {
                    _context.Categories.Remove(category);
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
        public bool UpdateCategory(Category category)
        {
            try
            {
                var categoryToUpdate = GetCategoryById(category.CategoryId);
                if (categoryToUpdate != null)
                {
                    _context.Entry<Category>(category).State = EntityState.Modified;
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
