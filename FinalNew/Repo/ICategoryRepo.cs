using FinalNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Repo
{
     public interface ICategoryRepo
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryByID(int id);

        Task<Category> GetCategoryByName(string name);
        Task<Category> CreateCategory(Category category);
        Task<Category> EditCategory(Category category);
        Task<Category> DeleteCategory(int id);
    }
}
