using FinalNew.DbContextfolder;
using FinalNew.Models;
using FinalNew.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Services
{
    public class CategoryRepo : ICategoryRepo
    {
        private CategoryDbContext _categoryDbContext;
        public CategoryRepo(CategoryDbContext categoryDbContext)
        {
            _categoryDbContext = categoryDbContext;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            var createdData = await _categoryDbContext.Categories.AddAsync(category);
            await _categoryDbContext.SaveChangesAsync();

            return createdData.Entity;
            
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var deletedRow = await _categoryDbContext.Categories.FirstOrDefaultAsync(model => model.CategoryID == id);
            if(deletedRow!=null)
            {
              _categoryDbContext.Categories.Remove(deletedRow);
                _categoryDbContext.SaveChanges();
            }
            return deletedRow;
        }

        public async Task<Category> EditCategory(Category category)
        {
            var result = await _categoryDbContext.Categories.FirstOrDefaultAsync(model => model.CategoryID== category.CategoryID);

            if (result != null)
            {
                result.CategoryID = category.CategoryID;
                result.CategoryName = category.CategoryName;
            }
            return result;
        }
      

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var CategoriesList = await _categoryDbContext.Categories.ToListAsync();

            return CategoriesList;
        }

        public async Task<Category> GetCategoryByID(int id)
        {
            var CategoryID = await _categoryDbContext.Categories.FirstOrDefaultAsync(model => model.CategoryID == id);

            return CategoryID;
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            var CategoryName = await _categoryDbContext.Categories.FirstOrDefaultAsync(model => model.CategoryName==name);

            return CategoryName;
        }
    }
}
