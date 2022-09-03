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
    public class ProductRepo : IProductRepo
    {
        private CategoryDbContext _categoryDbContext;
        public ProductRepo(CategoryDbContext categoryDbContext)
        {
            _categoryDbContext = categoryDbContext;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            if (product.Category != null)
            {
                _categoryDbContext.Entry(product.Category).State = EntityState.Unchanged;
            }

            var result = await _categoryDbContext.Products.AddAsync(product);
            await _categoryDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var deletedPro = await _categoryDbContext.Products.FirstOrDefaultAsync(model => model.ProductID == id);
            if(deletedPro!=null)
            {
                _categoryDbContext.Products.Remove(deletedPro);
                _categoryDbContext.SaveChanges();
            }
            return deletedPro;
        }

        public async Task<Product> EditProduct(Product product)
        {
            var editedPro = await _categoryDbContext.Products.FirstOrDefaultAsync(model => model.ProductID == product.ProductID);
            if(editedPro!=null)
            {
                editedPro.ProductID = product.ProductID;
                editedPro.ProductName = product.ProductName;
            }
            return editedPro;
        }

        public async Task<Product> GetProductByID(int id)
        {
            var getProId = await _categoryDbContext.Products.FirstOrDefaultAsync(model => model.ProductID == id);
            return getProId;

        }

        public async Task<Product> GetProductByName(string name)
        {
            var getProName = await _categoryDbContext.Products.FirstOrDefaultAsync(model => model.ProductName == name);
            return getProName;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var getPros = await _categoryDbContext.Products.ToListAsync();
            return getPros;
        }
    }
}
