using Business_Objects;
using MyStore_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo categoryRepo;
        public CategoryService()
        {
            categoryRepo = new CategoryRepo();
        }
        public bool CreateCategory(Category category)
        {
            return categoryRepo.CreateCategory(category);
        }

        public bool DeleteCategory(int id)
        {
            return categoryRepo.DeleteCategory(id);
        }

        public List<Category> GetCategories()
        {
            return categoryRepo.GetCategories();
        }

        public Category GetCategory(int id)
        {
            return categoryRepo.GetCategory(id);
        }

        public bool UpdateCategory(Category category)
        {
            return categoryRepo.UpdateCategory(category);
        }
    }
}
