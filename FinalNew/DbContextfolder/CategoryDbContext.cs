using FinalNew.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.DbContextfolder
{
    public class CategoryDbContext:DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext>options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
    
}
