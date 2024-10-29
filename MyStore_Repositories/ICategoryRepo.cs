using Business_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Repositories
{
    public interface ICategoryRepo
    {
        public List<Category> GetCategories();
        public Category GetCategory(int id);
        public bool CreateCategory(Category category);
        public bool DeleteCategory(int id);
        public bool UpdateCategory(Category category);
    }
}
