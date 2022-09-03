using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public virtual int Category_CategoryID { get; set; }
        [ForeignKey("Category_CategoryID")]

        public virtual Category Category { get; set; }
    }
}
