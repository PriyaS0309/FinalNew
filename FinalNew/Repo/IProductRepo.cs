using FinalNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Repo
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductByID(int id);

        Task<Product> GetProductByName(string name);
        Task<Product> CreateProduct(Product product);
        Task<Product> EditProduct(Product product);
        Task<Product> DeleteProduct(int id);
    }
}
