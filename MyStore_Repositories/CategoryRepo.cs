using Business_Objects;
using MyStore_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        public bool CreateCategory(Category category)
        {
            return CategoryDAO.Instance.CreateCategory(category);
        }

        public bool DeleteCategory(int id)
        {
            return CategoryDAO.Instance.DeleteCategory(id);
        }

        public List<Category> GetCategories()
        {
            return CategoryDAO.Instance.GetCategories();
        }

        public Category GetCategory(int id)
        {
            return CategoryDAO.Instance.GetCategoryById(id);
        }

        public bool UpdateCategory(Category category)
        {
            return CategoryDAO.Instance.UpdateCategory(category);
        }
    }
}
